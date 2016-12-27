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
			var studentId = new StudentTable(db).GetStudentId(User.Identity.GetUserId());
			ddlYear.DataSource = new StudentYearClassSectionRollTable(db).GetYearByStudentId(studentId);
			ddlYear.DataBind();
			LoadDDLTerm(null, null);
		}	

		protected void LoadDDLTerm(object o, EventArgs e) {
			//ddlTerm.DataSource = db.Query("getTermBySYCSRId", new Dictionary<string, object>() { { "SYCSRId", ddlYear.SelectedValue } }, true)
			//	.Select(x => new TextValuePair { Text = x["term"], Value = x["termid"] }).ToList();
			
			ddlTerm.DataSource = new TermYearClassSectionTable(db).
				GetTermByYearClassSection(Convert.ToInt32(ddlYear.SelectedValue));

			ddlTerm.DataBind();
			LoadDDLSubject(null, null);
		}

		protected void LoadDDLSubject(object obj, EventArgs e) {
			//var studentId = new UserTable<ApplicationUser>(db).GetUserId(User.Identity.Name);
			//var res = db.Query("getSubjectBySYCSRIdTId",
			//		new Dictionary<string, object>() { { "@SYCSRId", ddlYear.SelectedValue }, { "@TId", ddlTerm.SelectedValue } },
			//		true);
			var res = new TeacherSubjectTable(db).GetTeacherSubject(ddlYear.SelectedValue);
			ddlSubject.Items.Clear();
			foreach (var item in res) {
				ddlSubject.Items.Add(new ListItem(item.SubjectCode + " - " + item.Name, item.TeacherSubjectId));
			}
			ddlSubject.Items.Insert(0, new ListItem("All", "all"));
			LoadGridView(null, null);
		}


		protected void LoadGridView(object sender, EventArgs e) {
			//var studentId = new UserTable<ApplicationUser>(db).GetUserId(User.Identity.Name);

			//var dataSource = (ddlSubject.SelectedValue == "all") ?
			//	db.Query("getMarkBySUIdYCSIdTId",
			//	new Dictionary<string, object>() {
			//		{ "@SUId", studentId },
			//		{ "@YCSId", ddlYear.SelectedValue },
			//		{"@TId", ddlTerm.SelectedValue } },
			//	true) :
			//	db.Query("getMarkBySUIdTidTSId",
			//	new Dictionary<string, object>() {
			//		{ "@SUId", studentId },
			//		{"@TSId", ddlSubject.SelectedValue },
			//		{"@TId", ddlTerm.SelectedValue } },
			//	true);
			//List<string> markPortions = dataSource.Select(x => x["Portion Name"]).Distinct().ToList();
			//DataTable pivotTable = new DataTable();
			//pivotTable.Columns.Add("Subject", typeof(string));
			//foreach (var item in markPortions) {
			//	pivotTable.Columns.Add(item, typeof(string));
			//}
			//var subjects = dataSource.GroupBy(x => x["Subject"]).ToList();
			//foreach (var item in subjects) {
			//	DataRow newRow = pivotTable.Rows.Add();
			//	newRow["Subject"] = item.Key;
			//	foreach (var item2 in item) {
			//		newRow[item2["Portion Name"]] = item2["Mark"];
			//	}
			//}
			var studentId = new StudentTable(db).GetStudentId(User.Identity.GetUserId());
			var SYCSRId = new StudentYearClassSectionRollTable(db).
				GetStudentYearClassSectionRollId(ddlYear.SelectedValue, studentId);
			var dataSource = new MarkTable(db).GetStudentMark(SYCSRId, ddlTerm.SelectedValue);

			List<string> markPortions = dataSource.Select(x => x.MarkPortionName).Distinct().ToList();
			DataTable pivotTable = new DataTable();
			pivotTable.Columns.Add("Subject", typeof(string));

			foreach (var markPortion in markPortions) {
				pivotTable.Columns.Add(markPortion, typeof(string));
			}
			pivotTable.Columns.Add("Total", typeof(string));
			pivotTable.Columns.Add("Grade", typeof(string));

			var subjects = dataSource.GroupBy(x => x.Subject.ToString(false)).ToList();

			foreach (var subject in subjects) {
				DataRow newRow = pivotTable.Rows.Add();
				newRow["Subject"] = subject.Key;
				int total = 0;
				foreach (var portion in subject) {
					newRow[portion.MarkPortionName] = portion.Mark;
					total += (int)(Convert.ToDouble(portion.Mark));
				}
				newRow["Total"] = total;
				string grade = null;
				if (total >= 80)
					grade = "A+";
				else if (total >= 70)
					grade = "A";
				else if (total >= 60)
					grade = "A-";
				else if (total >= 50)
					grade = "B";
				else if (total >= 40)
					grade = "C";
				else if (total >= 33)
					grade = "D";
				else
					grade = "F";

				newRow["Grade"] = grade;
			}	

			gvMark.DataSource = pivotTable;
			gvMark.DataBind();
		}

		
	}
}