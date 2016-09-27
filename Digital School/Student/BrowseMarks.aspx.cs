using AspNet.Identity.MySQL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;
using Digital_School.Models;
using System.Data;

namespace Digital_School.Student
{
	public partial class BrowseMarks : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
            var studentId = new UserTable<ApplicationUser>(db).GetUserId(User.Identity.Name);
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
			List<string> markPortions = dataSource.Select(x => x["Portion Name"]).Distinct().ToList();
			DataTable pivotTable = new DataTable();
			pivotTable.Columns.Add("Subject", typeof(string));
			foreach (var item in markPortions) {
				pivotTable.Columns.Add(item, typeof(string));
			}
			var subjects = dataSource.GroupBy(x => x["Subject"]).ToList();
			foreach (var item in subjects) {
				DataRow newRow = pivotTable.Rows.Add();
				newRow["Subject"] = item.Key;
				foreach (var item2 in item) {
					newRow[item2["Portion Name"]] = item2["Mark"];
				}
			}
			
			gvMark.DataSource = pivotTable;
			gvMark.DataBind();
		}

        protected void gvMark_RowEditing(object sender, GridViewEditEventArgs e) {

        }
    }
}