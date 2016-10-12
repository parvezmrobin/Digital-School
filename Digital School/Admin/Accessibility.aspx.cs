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
		private MySQLDatabase db = new MySQLDatabase();
		//ddlTransact not working
		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				LoadDDLTeacher();
				LoadStudentClass();
				hInfo.Visible = false;
			}
		}

		private void LoadDDLTeacher() {
			
			ddlTeacher.DataSource = new TeacherTable(db).GetAllTeacher().Select(x => new { Text = x.FullName, Value = x.ID.ToString() }).ToList();
			ddlTeacher.DataBind();

			hInfo.Visible = false;
		}

		private void LoadStudentClass() {
			var yearId = new YearTable(db).GetYearId(DateTime.Now.Year);

			ddlClass.DataSource = new YearClassSectionTable(db).GetClassByYear(yearId);
			ddlClass.DataBind();

			if (ddlClass.Items.Count > 0)
				ReloadDDLSection(yearId);
			else {
				ddlSection.Items.Clear();
			}
		}
		private void ReloadDDLSection(int yearId) {
			ddlSection.DataSource = new YearClassSectionTable(db).GetSectionByYearClass(yearId, Convert.ToInt32(ddlClass.SelectedValue));
			ddlSection.DataBind();

			if (ddlSection.Items.Count > 0)
				ReloadDDLCanTransact(yearId);
			else
				ddlTransact.Enabled = false;
			hInfo.Visible = false;
		}

		private void ReloadDDLCanTransact(int yearId) {
			var YCSId = new YearClassSectionTable(db).GetYearClassSectionId(yearId, Convert.ToInt32(ddlClass.SelectedValue), Convert.ToInt32(ddlSection.SelectedValue));

			ddlTransact.SelectedValue = db.Execute(
				"canTransact",
				new Dictionary<string, object>() {
					{"@Tid", Convert.ToInt32(ddlTeacher.SelectedValue) },
					{"@YCSId", YCSId }
				}, true).ToString();
		}

		protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e) {
			var yearId = new YearTable(db).GetYearId(DateTime.Now.Year);
			ReloadDDLSection(yearId);
		}
		protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e) {
			var yearId = new YearTable(db).GetYearId(DateTime.Now.Year);
			//var teacherId = Context.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(User.Identity.Name).Id;
			ReloadDDLCanTransact(yearId);
			hInfo.Visible = false;
		}

		protected void ddlTeacher_SelectedIndexChanged(object sender, EventArgs e) {
			var yearId = new YearTable(db).GetYearId(DateTime.Now.Year);
			//var teacherId = Context.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(User.Identity.Name).Id;
			ReloadDDLCanTransact(yearId);
			hInfo.Visible = false;
		}

		protected void ddlTransact_SelectedIndexChanged(object sender, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			var yearId = new YearTable(db).GetYearId(DateTime.Now.Year);
			var YCSId = new YearClassSectionTable(db).GetYearClassSectionId(yearId, Convert.ToInt32(ddlClass.SelectedValue), Convert.ToInt32(ddlSection.SelectedValue));

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