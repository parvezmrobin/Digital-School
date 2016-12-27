using AspNet.Identity.MySQL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School.Teacher
{
	public partial class EditStudent : System.Web.UI.Page
	{
		protected void Page_Init(object sender, EventArgs e) {
			if (!IsPostBack) {
				LoadDDL();
			}
		}

		private void LoadDDL() {
			MySQLDatabase db = new MySQLDatabase();
			var yearId = db.QueryValue("getYearId", new Dictionary<string, object>() { { "@pyear", DateTime.Now.Year } }, true);
			var teacherId = Context.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(User.Identity.Name).Id;

			
			ddlClass.DataSource = db.Query(
				"getClassByTUIdYId",
				new Dictionary<string, object>() {
						{ "@TUId", teacherId },
						{ "@YId", yearId } },
				true)
				.Select(x => new {
					Text = x["class"],
					Value = x["classid"]
				}).ToList();
			ddlClass.DataBind();
			
			ReloadDDLSection(teacherId, yearId);
		}

		private void ReloadDDLStudent(object teacherId, object yearId) {
			MySQLDatabase db = new MySQLDatabase();
			var YCSId = db.QueryValue("getYearClassSectionId",
				new Dictionary<string, object>() {
					{"@pyearid", yearId },
					{"@pclassid", ddlClass.SelectedValue },
					{"@psectionid", ddlSection.SelectedValue }
				}, true);

			ddlStudent.DataSource = db.Query("getStudentByTUNYCSId",
				new Dictionary<string, object>() {
					{"@TUN", User.Identity.Name },
					{"@YCSId", YCSId }
				}, true).Select(x => new {
					Text = x["firstname"]+x["lastname"],
					Value = x["studentid"]
				}).ToList();
			ddlStudent.DataBind();
			//Reload Textboxes according to new ddl selection
			ReloadTextBox(Convert.ToInt32(ddlStudent.SelectedValue), (int)YCSId);
		}

		private void ReloadTextBox(int studentId, int yCSId) {
			//getClassSectionRollBySIdYCSId
			var res = new MySQLDatabase().Query(
				"getClassSectionRollBySIdYCSId",
				new Dictionary<string, object>() {
					{"@SId", studentId },
					{"@YCSId", yCSId }
				}, true);
			if (res.Count == 0)
				Response.Redirect(Statics.Error, true);

			txtClass.Text = res[0]["classid"];
			txtSection.Text = res[0]["sectionid"];
			txtRoll.Text = res[0]["roll"];
		}

		private void ReloadDDLSection(object teacherId, object yearId) {
			MySQLDatabase db = new MySQLDatabase();
			ddlSection.DataSource = db.Query(
					"getSectionByTUIdYIdCId",
					new Dictionary<string, object>() {
						{"@TUId", teacherId },
						{"@YId", yearId },
						{"@CId", ddlClass.SelectedValue }
					}, true)
					.Select(x => new {
						Text = x["section"],
						Value = x["sectionid"]
					}).ToList();
			ddlSection.DataBind();

			ReloadDDLStudent(teacherId, yearId);
		}

		protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			var yearId = db.QueryValue("getYearId", new Dictionary<string, object>() { { "@pyear", DateTime.Now.Year } }, true);
			var teacherId = Context.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(User.Identity.Name).Id;
			ReloadDDLSection(teacherId, yearId);
		}

		protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			var yearId = db.QueryValue("getYearId", new Dictionary<string, object>() { { "@pyear", DateTime.Now.Year } }, true);
			var teacherId = Context.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(User.Identity.Name).Id;
			ReloadDDLStudent(teacherId, yearId);
		}

		protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			var yearId = db.QueryValue("getYearId", new Dictionary<string, object>() { { "@pyear", DateTime.Now.Year } }, true);
			var YCSId = db.QueryValue("getYearClassSectionId",
				new Dictionary<string, object>() {
					{"@pyearid", yearId },
					{"@pclassid", ddlClass.SelectedValue },
					{"@psectionid", ddlSection.SelectedValue }
				}, true);

			ReloadTextBox(Convert.ToInt32(ddlStudent.SelectedValue), (int)YCSId);
		}

		protected void btnApply_Click(object sender, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			var yearId = db.QueryValue("getYearId", new Dictionary<string, object>() { { "@pyear", DateTime.Now.Year } }, true);
			var YCSId = db.QueryValue("getYearClassSectionId",
				new Dictionary<string, object>() {
					{"@pyearid", yearId },
					{"@pclassid", Convert.ToInt32(txtClass.Text) },
					{"@psectionid", Convert.ToInt32(txtSection.Text) }
				}, true);

			if(YCSId == null) {
				info.Attributes["class"] = "text-danger";
			} else {
				db.Execute("changeStudent",
					new Dictionary<string, object>() {
						{"@SId", ddlStudent.SelectedValue },
						{"@YCSId", YCSId },
						{"@proll", Convert.ToInt32(txtRoll.Text) }
					}, true);
			}
		}
	}
}