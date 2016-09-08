using AspNet.Identity.MySQL;
using Digital_School.User_Control;
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
	public partial class InputResult : Page
	{
		protected void Page_Init(object sender, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			var teacherId = Context.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(User.Identity.Name).Id;

			if (!IsPostBack) {

				#region Load ddlYear
				var res = db.Query(
					"getYearByTUId",
					new Dictionary<string, object>() { { "@TUId", teacherId } },
					true);
				ddlYear.Items.Clear();
				foreach (var item in res) {
					ddlYear.Items.Add(new ListItem(item["year"], item["yearid"]));
				}
				#endregion

				#region Load ddlClass
				ddlClass.DataSource = db.Query(
					"getClassByTUIdYId",
					new Dictionary<string, object>() {
						{ "@TUId", teacherId },
						{ "@YId", ddlYear.SelectedValue } },
					true)
					.Select(x => new {
						Text = x["class"],
						Value = x["classid"]
					}).ToList();
				ddlClass.DataTextField = "Text";
				ddlClass.DataValueField = "Value";
				ddlClass.DataBind();
				#endregion

				#region Load ddlSection
				ddlSection.DataSource = db.Query(
					"getSectionByTUIdYIdCId",
					new Dictionary<string, object>() {
						{"@TUId", teacherId },
						{"@YId", ddlYear.SelectedValue },
						{"@CId", ddlClass.SelectedValue }
					}, true)
					.Select(x => new {
						Text = x["section"],
						Value = x["sectionid"]
					}).ToList();
				ddlSection.DataTextField = "Text";
				ddlSection.DataValueField = "Value";
				ddlSection.DataBind();
				#endregion

				ReloadYCSId(null, null);

				#region Load ddlSubject
				ddlSubject.DataSource = db.Query(
					"getSubjectByTUIdYCSId",
					new Dictionary<string, object>() {
						{"@TUId", teacherId },
						{"@YCSId", ViewState["YCSId"] } },
					true)
					.Select(x => new {
						Text = x["subject"],
						Value = x["subjectid"]
					}).ToList();
				ddlSubject.DataTextField = "Text";
				ddlSubject.DataValueField = "Value";
				ddlSubject.DataBind();
				#endregion

				#region Load ddlStudent
				ddlStudent.DataSource = db.Query(
					"getStudentByTUNYCSIdSId",
					new Dictionary<string, object>() {
						{"@TUN", User.Identity.Name },
						{"@YCSId", ViewState["YCSId"] },
						{"@SId", ddlSubject.SelectedValue }
					},
					true).Select(x => new {
						Text = x["student"],
						Value = x["studentid"]
					}).ToList();
				ddlStudent.DataTextField = "Text";
				ddlStudent.DataValueField = "Value";
				ddlStudent.DataBind();
				#endregion
			}


			//TODO Implement rest of Input Result
		}
		protected void Page_LoadComplete(object sender, EventArgs e) {
			if (ViewState["YCSId"] == null)
				ReloadYCSId(null, null);

			var teacherId = Context.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(User.Identity.Name).Id;
			MySQLDatabase db = new MySQLDatabase();
			#region Load Mark
			int teacherSubjectId = Convert.ToInt32(
				db.QueryValue("getTeacherSubjectId",
				new Dictionary<string, object>() {
					{"@TUN", User.Identity.Name },
					{"@ycsid", ViewState["YCSId"] },
					{"@psubjectid", ddlSubject.SelectedValue } },
				true));
			var res2 = db.Query("getMarkPortionIdByTSId", new Dictionary<string, object>() { { "@TSId", teacherSubjectId } }, true);

			marks.Controls.Clear();
			//ViewState["clicks"] = new List<MarkPortion>();
			foreach (var item in res2) {
				MarkPortion markPortion = LoadControl("~/User Control/MarkPortion.ascx") as MarkPortion;
				markPortion.PortionName = item["portionname"];
				markPortion.MarkPortionId = Convert.ToInt32(item["markportionid"]);
				var resMark = db.Query("getMarkByMPIdSId",
					new Dictionary<string, object>() {
						{"@MPId", item["markportionid"] },
						{"@SId", ddlStudent.SelectedValue }
					}, true);
				if (resMark.Count == 0)
					Response.Redirect(Statics.Error, true);
				markPortion.Mark = Convert.ToInt32(resMark[0]["mark"]);
				markPortion.MarkId = Convert.ToInt32(resMark[0]["markid"]);
				markPortion.SubmitClick += delegate {
					int mark;
					if (markPortion.MarkId == null) {
						if (!string.IsNullOrEmpty(markPortion.Mark.ToString()) &&
							int.TryParse(markPortion.Mark.ToString(), out mark)) {
							int SYCSRId = Convert.ToInt32(db.QueryValue("getSYCSRIdByYCSIdSId",
								new Dictionary<string, object>() {
									{ "@YCSId", ViewState["YCSId"] },
									{ "@SId", ddlStudent.SelectedValue } },
								true));

							db.Execute("addMark", new Dictionary<string, object>() {
								{ "@MPId", markPortion.MarkPortionId},
								{ "@SYCSRId", SYCSRId },
								{ "@termid", ddlTerm.SelectedValue },
								{ "@mark", mark },
								{ "@TUId",  teacherId}
							}, true);

						}
					} else {
						db.Execute("updateMark",
							new Dictionary<string, object>() {
									{"@pid", markPortion.MarkId },
									{"@mark", markPortion.Mark }
							}, true);
					}
				};
				//(ViewState["clicks"] as List<MarkPortion>).Add(markPortion);
				marks.Controls.Add(markPortion);
			}
			#endregion
		}

		protected void ReloadYCSId(object obj, EventArgs ea) {
			ViewState["YCSId"] = Convert.ToInt32(new MySQLDatabase().QueryValue(
					"getYearClassSectionId",
					new Dictionary<string, object>() {
						{"@pyearid", ddlYear.SelectedValue },
						{"@pclassid", ddlClass.SelectedValue },
						{"@psectionid", ddlSection.SelectedValue } },
					true));
		}

		protected void MarkPortion_Click(object sender, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			if (sender is MarkPortion) {
				
			}
		}

		protected void btnSubmit_Click(object sender, EventArgs e) {
			foreach (var item in (ViewState["clicks"] as List<MarkPortion>)) {
				item.OnSubmitClick(new EventArgs());
			}
		}
	}
}