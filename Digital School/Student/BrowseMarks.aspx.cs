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
		private MySQLDatabase db = new MySQLDatabase();
		protected void Page_Init(object sender, EventArgs e) {
			
            if (!IsPostBack) {
				LoadDDLYear(null, null);
			}
		}

		protected void LoadDDLYear(object obj, EventArgs e) {
			var studentId = new UserTable<ApplicationUser>(db).GetUserId(User.Identity.Name);
			ddlYear.DataSource = new StudentYearClassSectionRollTable(db).GetYearByStudentUserId(studentId);
			ddlYear.DataBind();
			LoadDDLTerm(null, null);
		}	

		protected void LoadDDLTerm(object o, EventArgs e) {
			ddlTerm.DataSource = db.Query("getTermBySYCSRId", new Dictionary<string, object>() { { "SYCSRId", ddlYear.SelectedValue } }, true)
				.Select(x => new TextValuePair { Text = x["term"], Value = x["termid"] }).ToList();
			ddlTerm.DataBind();
			LoadDDLSubject(null, null);
		}

		protected void LoadDDLSubject(object obj, EventArgs e) {
			var studentId = new UserTable<ApplicationUser>(db).GetUserId(User.Identity.Name);
			var res = db.Query("getSubjectBySYCSRIdTId",
					new Dictionary<string, object>() { { "@SYCSRId", ddlYear.SelectedValue }, { "@TId", ddlTerm.SelectedValue } },
					true);
			ddlSubject.Items.Clear();
			foreach (var item in res) {
				ddlSubject.Items.Add(new ListItem(item["subject"], item["teacherSubjectId"]));
			}
			ddlSubject.Items.Insert(0, new ListItem("All", "all"));
			LoadGridView(null, null);
		}
		protected void LoadGridView(object sender, EventArgs e) {
			var studentId = new UserTable<ApplicationUser>(db).GetUserId(User.Identity.Name);

			var dataSource = (ddlSubject.SelectedValue == "all") ?
				db.Query("getMarkBySUIdYCSIdTId",
				new Dictionary<string, object>() {
					{ "@SUId", studentId },
					{ "@YCSId", ddlYear.SelectedValue },
					{"@TId", ddlTerm.SelectedValue } },
				true) :
				db.Query("getMarkBySUIdTidTSId",
				new Dictionary<string, object>() {
					{ "@SUId", studentId },
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

		
	}
}