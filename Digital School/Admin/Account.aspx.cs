using AspNet.Identity.MySQL;
using Digital_School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace Digital_School.Admin
{
	public partial class Account : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				LoadDDLTeacher();
				LoadDDLDesignation();
				success1.Visible = false;
				success2.Visible = false;
				info.Visible = false;
				LoadStudentDDL();
			}
			
		}

		private void LoadStudentDDL() {
			MySQLDatabase db = new MySQLDatabase();
			var yearId = db.QueryValue("getYearId", new Dictionary<string, object>() { { "@pyear", DateTime.Now.Year } }, true);
			//var teacherId = new UserTable<ApplicationUser>(db).GetUserId(User;


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
				ddlStudent.Items.Clear();
			}
		}

		private void ReloadDDLSection(object yearId) {
			MySQLDatabase db = new MySQLDatabase();
			ddlSection.DataSource = db.Query(
					"getSectionByYIdCId",
					new Dictionary<string, object>() {
						{"@YId", yearId },
						{"@CId", ddlClass.SelectedValue }
					}, true)
					.Select(x => new {
						Text = x["section"],
						Value = x["sectionid"]
					}).ToList();
			ddlSection.DataBind();

			if (ddlSection.Items.Count > 0)
				ReloadDDLStudent(yearId);
			else
				ddlStudent.Items.Clear();
		}

		private void ReloadDDLStudent(object yearId) {
			
			MySQLDatabase db = new MySQLDatabase();
			var YCSId = db.QueryValue("getYearClassSectionId",
				new Dictionary<string, object>() {
					{"@pyearid", yearId },
					{"@pclassid", ddlClass.SelectedValue },
					{"@psectionid", ddlSection.SelectedValue }
				}, true);

			ddlStudent.DataSource = db.Query("getStudentByYCSId",
				new Dictionary<string, object>() {
					{"@YCSId", YCSId }
				}, true).Select(x => new {
					Text = x["student"],
					Value = x["studentid"]
				}).ToList();
			ddlStudent.DataBind();
			//Reload Textboxes according to new ddl selection
			if (ddlStudent.Items.Count > 0) { 
				ReloadTextBox(Convert.ToInt32(ddlStudent.SelectedValue), (int)YCSId);
			} else {
				txtClass.Text = string.Empty;
				txtSection.Text = string.Empty;
				txtRoll.Text = string.Empty;
			}
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
				throw new ArgumentException("No data found from procedure 'getClassSectionRollBySIdYCSId'.");

			txtClass.Text = res[0]["classid"];
			txtSection.Text = res[0]["sectionid"];
			txtRoll.Text = res[0]["roll"];

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
			ReloadDDLStudent(yearId);
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
			try {
				MySQLDatabase db = new MySQLDatabase();
				var yearId = db.QueryValue("getYearId", new Dictionary<string, object>() { { "@pyear", DateTime.Now.Year } }, true);
				var YCSId = db.QueryValue("getYearClassSectionId",
					new Dictionary<string, object>() {
					{"@pyearid", yearId },
					{"@pclassid", Convert.ToInt32(txtClass.Text) },
					{"@psectionid", Convert.ToInt32(txtSection.Text) }
					}, true);

				if (YCSId == null) {
					info.Visible = true;
					success2.Visible = false;
				} else {
					db.Execute("changeStudent",
						new Dictionary<string, object>() {
						{"@SId", ddlStudent.SelectedValue },
						{"@YCSId", YCSId },
						{"@proll", Convert.ToInt32(txtRoll.Text) }
						}, true);
					success2.Visible = true;
					info.Visible = false;
					ReloadDDLStudent(yearId);
				}
			} catch (Exception) {
				info.Visible = true;
				success2.Visible = false;
			}
			
		}


		private void LoadDDLTeacher() {
			MySQLDatabase db = new MySQLDatabase();
			ddlTeacher.DataSource = db.Query("getAllTeacher", null, true).Select(x => new { Text = x["name"], Value = x["id"] }).ToList();
			ddlTeacher.DataBind();
		}

		private void LoadDDLDesignation() {
			MySQLDatabase db = new MySQLDatabase();
			ddlDesignation.DataSource = db.Query("getAllDesignation", null, true).Select(x => new { Text = x["designation"], Value = x["id"] }).ToList();
			ddlDesignation.DataBind();

			ChangeDDLDesignationAsDDLTeacher(null, null);
		}

		protected void ChangeDDLDesignationAsDDLTeacher(object obj, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			ddlDesignation.SelectedValue = db.GetStrValue(
				"getDesignationIdByTUId",
				new Dictionary<string, object>() { { "TId", ddlTeacher.SelectedValue } },
				true);
		}

		protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e) {
			//changeDesignation
			MySQLDatabase db = new MySQLDatabase();
			db.Execute("changeDesignation",
				new Dictionary<string, object>() {
					{"@designationId", ddlDesignation.SelectedValue },
					{"@TId", ddlTeacher.SelectedValue }
				}, true);
			success1.Visible = true;
			
		}
	}
}