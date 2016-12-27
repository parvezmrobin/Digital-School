using AspNet.Identity.MySQL;
using Digital_School.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace Digital_School.Student
{
	public partial class GraphicalView : System.Web.UI.Page
	{
		//TODO Browse Subjectwise
		private MySQLDatabase db = new MySQLDatabase();

		protected void Page_Init(object sender, EventArgs e) {
			if (!IsPostBack) {
				var studentId = new StudentTable(db).GetStudentId(User.Identity.GetUserId());
				ddlYear.DataSource = new StudentYearClassSectionRollTable(db).
					GetYearByStudentId(studentId);
				ddlYear.DataBind();

				LoadDDLTerm(null, null);		
			}			
		}

		protected void LoadDDLTerm(object o, EventArgs e) {
			ddlTerm.DataSource = new TermYearClassSectionTable(db).
					GetTermByYearClassSection(int.Parse(ddlYear.SelectedValue));
			ddlTerm.DataBind();

			LoadDDLSubject(null, null);
		}

		protected void LoadDDLSubject(object o, EventArgs e) {
			ddlSubject.DataSource = new TeacherSubjectTable(db).
					GetTeacherSubject(ddlYear.SelectedValue).
					Select(x => new TextValuePair { Text = x.SubjectCode + " - " + x.Name, Value = x.TeacherSubjectId }).ToList();
			ddlSubject.DataBind();

			ReloadChart(null, null);
		}

		protected void ReloadChart(object sender, EventArgs e) {
			var studentId = new StudentTable(db).GetStudentId(User.Identity.GetUserId());
			var SYCSRId = new StudentYearClassSectionRollTable(db).
				GetStudentYearClassSectionRollId(ddlYear.SelectedValue, studentId);


			var dataSource = new MarkTable(db).
				GetStudentMark(SYCSRId, ddlTerm.SelectedValue, ddlSubject.SelectedValue);

			Series series = new Series(ddlSubject.SelectedItem.Text);
			Chart1.Series.Add(series);
			series.ChartType = SeriesChartType.Spline;
			//var groups = dataSource.GroupBy(x => x.MarkPortionName);
			foreach (var mark in dataSource) {
				series.Points.AddXY(mark.MarkPortionName, mark.Mark);
			}

		}
	}
}