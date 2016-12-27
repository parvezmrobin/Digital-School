using AspNet.Identity.MySQL;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School.Teacher
{
	public partial class Promote : Page
	{
		MySQLDatabase db = new MySQLDatabase();
		YearClassSectionTable YCSTable = new YearClassSectionTable(new MySQLDatabase());

		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				var res = new YearTable(db).GetAllYear();
				ddlFromYear.DataSource = res;
				ddlFromYear.DataBind();
				ReloadDDLFromClass(null, null);

				ddlToYear.DataSource = res;
				ddlToYear.DataBind();
				ReloadDDLToClass(null, null);

				hPromote.Visible = false;
			}
		}

		protected void ReloadDDLFromClass(object o, EventArgs e) {
			ddlFromClass.DataSource = YCSTable.GetClassByYear(ddlFromYear.SelectedValue);
			ddlFromClass.DataBind();

			ReloadDDLFromSection(null, null);
		}

		protected void ReloadDDLFromSection(object obje, EventArgs ea) {
			ddlFromSection.DataSource = YCSTable.GetSectionByYearClass(ddlFromYear.SelectedValue, ddlFromClass.SelectedValue);
			ddlFromSection.DataBind();

			BindGridView(null, null);
		}

		protected void ReloadDDLToClass(object o, EventArgs e) {
			ddlToClass.DataSource = YCSTable.GetClassByYear(ddlToYear.SelectedValue);
			ddlToClass.DataBind();

			ReloadDDLToSection(null, null);
		}

		protected void ReloadDDLToSection(object o, EventArgs e) {
			ddlToSection.DataSource = YCSTable.
				GetSectionByYearClass(ddlToYear.SelectedValue, ddlToClass.SelectedValue);
			ddlToSection.DataBind();
		}
		protected void BindGridView(object p1, EventArgs p2) {
			var students = new StudentTable(db).
				GetStudents(ddlFromYear.SelectedValue, ddlFromClass.SelectedValue, ddlFromSection.SelectedValue);
			var marks = new MarkTable(db).
				GetYearlyMark(ddlFromYear.SelectedValue, ddlFromClass.SelectedValue, ddlFromSection.SelectedValue);
			var orderedMarks = marks.OrderByDescending(x => x.Mark).ToList();
			for(int i = 1; i<=orderedMarks.Count; i++) {
				orderedMarks[i - 1].MarkId = i.ToString();
			}
			gvPromote.DataSource = orderedMarks;
			gvPromote.DataBind();
		}

		protected void Unnamed_Click(object sender, EventArgs e) {
			foreach (GridViewRow row in gvPromote.Rows) {
				if((row.FindControl("cb") as CheckBox).Checked) {
					new StudentYearClassSectionRollTable(db).AddStudentYearClassSectionRoll(
						(row.FindControl("StudentId") as HiddenField).Value,
						YCSTable.GetYearClassSectionId(ddlToYear.SelectedValue, ddlToClass.SelectedValue, ddlToSection.SelectedValue),
						(row.FindControl("NextRoll") as Label).Text
						);
					(row.FindControl("cb") as CheckBox).Checked = false;
					hPromote.Visible = true;
					
				}
			}
		}
	}
}
