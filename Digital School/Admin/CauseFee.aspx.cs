using AspNet.Identity.MySQL;
using Digital_School.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School.Admin
{
	public partial class CauseFee : System.Web.UI.Page
	{
		private MySQLDatabase db = new MySQLDatabase();
		private object yearId;
		protected void Page_Init(object sender, EventArgs e) {
			yearId = db.QueryValue("getYearId", new Dictionary<string, object>() { { "@pyear", DateTime.Now.Year } }, true);

			if (!IsPostBack) {
				LoadDDLClass(null, null);
				LoadDDLType(null, null);
				hSuccess.Visible = false;
			}
		}

		protected void LoadDDLClass(object o, EventArgs e) {
			ddlClass.DataSource = db.Query("getClassByYId", new Dictionary<string, object>() { { "@yid", yearId } }, true).
				Select(x => new TextValuePair { Text = x["class"], Value = x["classid"] }).ToList();
			ddlClass.DataBind();

			LoadDDLSection(null, null);
		}

		protected void LoadDDLSection(object o, EventArgs e) {
			var res = db.Query("getSectionByYIdCId",
				new Dictionary<string, object>() {
					{"@YId", yearId },
					{"@CId", ddlClass.SelectedValue }
				}, true).
				Select(x => new TextValuePair { Text = x["section"], Value = x["sectionid"] }).ToList();
			ddlSection.DataSource = res;
			ddlSection.DataBind();
		}

		protected void LoadDDLType(object o, EventArgs e) {
			ddlType.DataSource = db.Query("getAllTransactionType", null, true).
				Select(x => new TextValuePair { Text = x["name"], Value = x["id"] }).ToList();
			ddlType.DataBind();
		}

		protected void btnCauseFee_Click(object sender, EventArgs e) {
			var YCSId = db.QueryValue("getYearClassSectionId", new Dictionary<string, object>() {
				{"@pclassid", ddlClass.SelectedValue },
				{"@psectionid", ddlSection.SelectedValue },
				{"@pyearid", yearId }
			}, true);

			var studentIds = db.Query("getStudentByYCSId", new Dictionary<string, object>() { { "@YCSId", YCSId } }, true).
				Select(x => new SingleValue { Value = x["studentid"] }).ToList();
			var userId = User.Identity.GetUserId();

			foreach (var studentId in studentIds) {
				db.Execute("causeFee", new Dictionary<string, object>() {
					{"@SId", studentId.Value },
					{"@doneBy", userId },
					{"@TId", ddlType.SelectedValue },
					{"@amount", txtAmount.Text }
				}, true);
			}

			hSuccess.InnerText = "Tk " + txtAmount.Text + " is caused to Class " + ddlClass.SelectedItem.Text + ", Section " + ddlSection.SelectedItem.Text + " for " + ddlType.SelectedItem.Text + ".";
			hSuccess.Visible = true;
		}
	}
}