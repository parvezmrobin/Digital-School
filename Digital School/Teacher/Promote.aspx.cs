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
	public partial class Promote : Page
	{
		MySQLDatabase db = new MySQLDatabase();

		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				var res = new TeacherSubjectTable(db).GetYear(User.Identity.GetUserId());
				ddlFromYear.DataSource = res;
				ddlFromYear.DataBind();
				ReloadDDLFromClass(null, null);

				ddlToYear.DataSource = res;
				ddlToYear.DataBind();
				ReloadDDLToClass(null, null);
			}
		}

		protected void ReloadDDLFromClass(object o, EventArgs e) {
			ddlFromClass.DataSource = new TeacherSubjectTable(db).GetClass(User.Identity.GetUserId(), ddlFromYear.SelectedValue);
			ddlFromClass.DataBind();

			ReloadDDLFromSection(null, null);
		}

		protected void ReloadDDLFromSection(object obje, EventArgs ea) {
			ddlFromSection.DataSource = new TeacherSubjectTable(db).GetSection(User.Identity.GetUserId(), ddlFromYear.SelectedValue, ddlFromClass.SelectedValue);
			ddlFromSection.DataBind();

			BindGridView(null, null);
		}

		protected void ReloadDDLToClass(object o, EventArgs e) {
			ddlToClass.DataSource = new YearClassSectionTable(db).GetClassByYear((ddlToYear.SelectedValue));
			ddlToClass.DataBind();

			ReloadDDLToSection(null, null);
		}

		protected void ReloadDDLToSection(object o, EventArgs e) {
			ddlToSection.DataSource = new YearClassSectionTable(db).GetSectionByYearClass(ddlToYear.SelectedValue, ddlToClass.SelectedValue);
			ddlToSection.DataBind();
		}
		protected void BindGridView(object p1, EventArgs p2) {
			var students = new StudentTable(db).GetStudents(ddlFromYear.SelectedValue, ddlFromClass.SelectedValue, ddlFromSection.SelectedValue);
			var marks = new MarkTable(db).GetYearlyMark(ddlFromYear.SelectedValue, ddlFromClass.SelectedValue, ddlFromSection.SelectedValue);
			var orderedMarks = marks.OrderByDescending(x => x.Mark).ToList();
			for (int i = 0; i < orderedMarks.Count; i++) {
				marks.Find(x => x.Student.ID == orderedMarks[i].Student.ID).MarkId = (i + 1).ToString();
			}
			gvPromote.DataSource = marks;
			gvPromote.DataBind();
		}

		protected void Unnamed_Click(object sender, EventArgs e) {
			foreach (GridViewRow row in gvPromote.Rows) {
				if((row.FindControl("cb") as CheckBox).Checked) {
					new StudentYearClassSectionRollTable(db).AddStudentYearClassSectionRoll(
						(row.FindControl("StudentId") as HiddenField).Value,
						new YearClassSectionTable(db).GetYearClassSectionId(ddlToYear.SelectedValue, ddlToClass.SelectedValue, ddlToSection.SelectedValue),
						(row.FindControl("NextRoll") as Label).Text
						);
				}
			}
		}
	}
}
