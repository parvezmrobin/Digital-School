using AspNet.Identity.MySQL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;

namespace Digital_School.Student
{
	public partial class BrowseMarks : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e) {
			// TODO Implement BrowseMarks
			
			MySQLDatabase db = new MySQLDatabase();
			var studentId = Context.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(User.Identity.Name).Id;
			if (!IsPostBack) {
				var res = db.Query("getYearByStudentUserid",
					new Dictionary<string, object>() { { "@pid", studentId } },
					true);
				ddlYear.Items.Clear();
				foreach (var item in res) {
					ddlYear.Items.Add(new ListItem(item["year"], item["YearClassSectionId"]));
				}

				res = db.Query("getSubjectBySUIdYCSId",
					new Dictionary<string, object>() { { "@SUId", studentId }, { "@YCSId", ddlYear.SelectedValue } },
					true);
				ddlSubject.Items.Clear();
				foreach (var item in res) {
					ddlSubject.Items.Add(new ListItem(item["subject"], item["teacherSubjectId"]));
				}
				ddlSubject.Items.Insert(0, new ListItem("All", "all"));
			}

			var dataSource = (ddlSubject.SelectedValue == "all") ?
				db.Query("getMarkBySUIdYCSIdTId",
				new Dictionary<string, object>() {
					{ "@SUId", studentId },
					{ "@YCSId", ddlYear.SelectedValue },
					{"@TId", ddlTerm.SelectedValue } },
				true) :
				db.Query("getMarkBySUIdYCSIdTidTSId",
				new Dictionary<string, object>() {
					{ "@SUId", studentId },
					{ "@YCSId", ddlYear.SelectedValue },
					{"@TSId", ddlSubject.SelectedValue },
					{"@TId", ddlTerm.SelectedValue } },
				true);
			
			gvMark.DataSource = dataSource.Select(x => new {
				Subject = x["Subject"],
				PortionName = x["Portion Name"],
				Mark = x["Mark"]
			}).ToList();
			gvMark.DataBind();
		}
	}
}