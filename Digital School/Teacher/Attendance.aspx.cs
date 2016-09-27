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
		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				MySQLDatabase db = new MySQLDatabase();
				var teacherId = Context.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(User.Identity.Name).Id;
				var yearId = db.QueryValue("getYearId", new Dictionary<string, object>() { { "@pyear", DateTime.Now.Year } }, true);
				#region Load ddlClass
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
				ddlClass.DataTextField = "Text";
				ddlClass.DataValueField = "Value";
				ddlClass.DataBind();
				#endregion

				ReloadDDLSection(null, null);
			}


		}

		private void BindCheckBoxes(object p1, EventArgs p2) {
			cbAttendance.DataSource = new MySQLDatabase().Query(
				"getStudentByTUNYCSId",
				 new Dictionary<string, object>() {
					 {"@TUN", User.Identity.Name }  ,
					 {"@YCSId", ViewState["YCSId"] }
				 }, true).Select(x => new {
					 Text = x["roll"] + ". " + x["student"],
					 Value = x["studentid"]
				 }).ToList();
			cbAttendance.DataBind();
		}

		protected void ReloadYCSId(object obj, EventArgs ea) {
			var yearId = new MySQLDatabase().QueryValue("getYearId", new Dictionary<string, object>() { { "@pyear", DateTime.Now.Year } }, true);
			ViewState["YCSId"] = Convert.ToInt32(new MySQLDatabase().QueryValue(
					"getYearClassSectionId",
					new Dictionary<string, object>() {
						{"@pyearid", yearId },
						{"@pclassid", ddlClass.SelectedValue },
						{"@psectionid", ddlSection.SelectedValue } },
					true));
			BindCheckBoxes(null, null);
		}

		protected void ReloadDDLSection(object obje, EventArgs ea) {
			MySQLDatabase db = new MySQLDatabase();
			var teacherId = Context.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(User.Identity.Name).Id;
			var yearId = db.QueryValue("getYearId", new Dictionary<string, object>() { { "@pyear", DateTime.Now.Year } }, true);

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
			ddlSection.DataTextField = "Text";
			ddlSection.DataValueField = "Value";
			ddlSection.DataBind();

			ReloadYCSId(null, null);
		}

		protected void btnSubmint_Click(object obj, EventArgs ea) {
			throw new NotImplementedException();
		}
	}
}