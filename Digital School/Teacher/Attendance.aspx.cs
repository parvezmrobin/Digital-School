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
	public partial class Attendance : Page
	{
		MySQLDatabase db = new MySQLDatabase();
		protected void Page_Init(object sender, EventArgs e) {
			if (!IsPostBack) {
				var teacherId = Context.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(User.Identity.Name).Id;
				var yearId = new YearTable(db).GetYearId(DateTime.Now.Year);

				ddlClass.DataSource = new TeacherSubjectTable(db).GetClass(teacherId, yearId);
				ddlClass.DataTextField = "Text";
				ddlClass.DataValueField = "Value";
				ddlClass.DataBind();

				ReloadDDLSection(null, null);
			}
		}

		protected void BindCheckBoxes(object p1, EventArgs p2) {
			var YCSId = new YearClassSectionTable(db).GetYearClassSectionId(new YearTable(db).GetYearId(DateTime.Now.Year), ddlClass.SelectedValue, ddlSection.SelectedValue);
			cbAttendance.DataSource = new TeacherSubjectTable(db).GetStudent(User.Identity.Name, YCSId).Select(x => new TextValuePair {
				Text = x.ToString(),
				Value = x.ID
			}).ToList();
			cbAttendance.DataBind();
			foreach (ListItem item in cbAttendance.Items) {
				item.Selected = true;
			}
		}

		//protected void ReloadYCSId(object obj, EventArgs ea) {
		//	var yearId = db.QueryValue("getYearId", new Dictionary<string, object>() { { "@pyear", DateTime.Now.Year } }, true);
		//	ViewState["YCSId"] = Convert.ToInt32(new MySQLDatabase().QueryValue(
		//			"getYearClassSectionId",
		//			new Dictionary<string, object>() {
		//				{"@pyearid", yearId },
		//				{"@pclassid", ddlClass.SelectedValue },
		//				{"@psectionid", ddlSection.SelectedValue } },
		//			true));
			
		//}

		protected void ReloadDDLSection(object obje, EventArgs ea) {
			var teacherId = new UserTable<IdentityUser>(db).GetUserId(User.Identity.Name);
			var yearId = new YearTable(db).GetYearId(DateTime.Now.Year);

			ddlSection.DataSource = new TeacherSubjectTable(db).GetSection(teacherId, yearId, ddlClass.SelectedValue);
			ddlSection.DataTextField = "Text";
			ddlSection.DataValueField = "Value";
			ddlSection.DataBind();

			BindCheckBoxes(null, null);
		}

		protected void btnSubmint_Click(object obj, EventArgs ea) {
			//TODO Not checked
			//TODO add trigger
			var YCSID = new YearClassSectionTable(db).GetYearClassSectionId(new YearTable(db).GetYearId(DateTime.Now.Year), ddlClass.SelectedValue, ddlSection.SelectedValue); 
			var markPortionId = db.QueryValue("getMarkPortionIdByYCSIdPId",
				new Dictionary<string, object>() {
					{"@YCSId", Convert.ToInt32(ViewState["YCSId"]) },
					{"@PId", -1 }
				}, true);

			foreach (ListItem item in cbAttendance.Items) {
				db.Execute("addAttendance", new Dictionary<string, object>() {
					{"@MPId", markPortionId },
					{"@SId", item.Value },
					{"@isPresent", item.Selected }
				}, true);
			}
		}
	}
}