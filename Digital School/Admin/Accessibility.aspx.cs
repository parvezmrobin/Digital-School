using AspNet.Identity.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School.Admin
{
	public partial class Accessibility : Page
	{
		//ddlTransact not working
		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				LoadDDLTeacher();
				LoadStudentClass();
				hInfo.Visible = false;
			}
		}

		private void LoadDDLTeacher() {
			MySQLDatabase db = new MySQLDatabase();
			ddlTeacher.DataSource = db.Query("getAllTeacher", null, true).Select(x => new { Text = x["name"], Value = x["id"] }).ToList();
			ddlTeacher.DataBind();

			hInfo.Visible = false;
		}

		private void LoadStudentClass() {
			MySQLDatabase db = new MySQLDatabase();
			var yearId = db.QueryValue("getYearId", new Dictionary<string, object>() { { "@pyear", DateTime.Now.Year } }, true);

			ddlClass.DataSource = db.Query(
				"getClassByYId",
				new Dictionary<string, object>() { { "@YId", yearId } },
				true)
				.Select(x => new {
					Text = x["class"],
					Value = x["classid"]
				}).ToList();
			ddlClass.DataBind();

			if (ddlClass.Items.Count > 0)
				ReloadDDLSection(yearId);
			else {
				ddlSection.Items.Clear();
			}
		}
		private void ReloadDDLSection(object yearId) {
			MySQLDatabase db = new MySQLDatabase();
			ddlSection.DataSource = db.Query(
					"getSectionByYIdCId",
					new Dictionary<string, object>() {
						{"@YId", yearId },
						{"@CId", Convert.ToInt32(ddlClass.SelectedValue) }
					}, true)
					.Select(x => new {
						Text = x["section"],
						Value = x["sectionid"]
					}).ToList();
			ddlSection.DataBind();

			if (ddlSection.Items.Count > 0)
				ReloadDDLCanTransact(yearId);
			else
				ddlTransact.Enabled = false;
			hInfo.Visible = false;
		}

		private void ReloadDDLCanTransact(object yearId) {
			MySQLDatabase db = new MySQLDatabase();
			var YCSId = db.QueryValue("getYearClassSectionId",
				new Dictionary<string, object>() {
					{"@pyearid", yearId },
					{"@pclassid", Convert.ToInt32(ddlClass.SelectedValue) },
					{"@psectionid", Convert.ToInt32(ddlSection.SelectedValue) }
				}, true);

			ddlTransact.SelectedValue = db.Execute(
				"canTransact",
				new Dictionary<string, object>() {
					{"@Tid", Convert.ToInt32(ddlTeacher.SelectedValue) },
					{"@YCSId", YCSId }
				}, true).ToString();
		}

		protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			var yearId = db.QueryValue("getYearId", new Dictionary<string, object>() { { "@pyear", DateTime.Now.Year } }, true);
			//var teacherId = Context.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(User.Identity.Name).Id;
			ReloadDDLSection(yearId);
		}
		protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			var yearId = db.QueryValue("getYearId", new Dictionary<string, object>() { { "@pyear", DateTime.Now.Year } }, true);
			//var teacherId = Context.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(User.Identity.Name).Id;
			ReloadDDLCanTransact(yearId);
			hInfo.Visible = false;
		}

		protected void ddlTeacher_SelectedIndexChanged(object sender, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			var yearId = db.QueryValue("getYearId", new Dictionary<string, object>() { { "@pyear", DateTime.Now.Year } }, true);
			//var teacherId = Context.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(User.Identity.Name).Id;
			ReloadDDLCanTransact(yearId);
			hInfo.Visible = false;
		}

		protected void ddlTransact_SelectedIndexChanged(object sender, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			var yearId = db.QueryValue("getYearId", new Dictionary<string, object>() { { "@pyear", DateTime.Now.Year } }, true);
			var YCSId = db.QueryValue("getYearClassSectionId",
				new Dictionary<string, object>() {
					{"@pyearid", yearId },
					{"@pclassid", ddlClass.SelectedValue },
					{"@psectionid", ddlSection.SelectedValue }
				}, true);

			if (ddlTransact.SelectedValue == "1") {
				db.Execute("addTransactionAccessibility",
					new Dictionary<string, object>() {
						{"@Tid", ddlTeacher.SelectedValue },
						{"@YCSId", YCSId }
					}, true);
				hInfo.InnerText = ddlTeacher.SelectedItem.Text + " now can access class " + ddlClass.SelectedItem.Text + ", section " + ddlSection.SelectedItem.Text;
				hInfo.Attributes["class"] = "text-success";
				hInfo.Visible = true;
			} else {
				db.Execute("removeTransactionAccessibility",
					new Dictionary<string, object>() {
						{"@TId", ddlTeacher.SelectedValue },
						{"@YCSId", YCSId }
					}, true);
				hInfo.InnerText = ddlTeacher.SelectedItem.Text + " now cannot access class " + ddlClass.SelectedItem.Text + ", section " + ddlSection.SelectedItem.Text;
				hInfo.Attributes["class"] = "text-danger";
				hInfo.Visible = true;
			}
		}
	}
}