using AspNet.Identity.MySQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School.Admin
{
	public partial class Tabulatation : Page
	{
		private MySQLDatabase db = new MySQLDatabase();
		private Dictionary<string, int> headerLength = new Dictionary<string, int>();
		protected void Page_Init(object sender, EventArgs e) {
			if (!IsPostBack) {
				LoadDDLYear(null, null);
			}
		}

		protected void LoadDDLYear(object p1, EventArgs p2) {
			ddlYear.DataSource = new YearTable(db).GetAllYear();
			ddlYear.DataBind();

			LoadDDLClass(null, null);
		}

		protected void LoadDDLClass(object p1, EventArgs p2) {
			ddlClass.DataSource = new YearClassSectionTable(db).GetClassByYear(ddlYear.SelectedValue);
			ddlClass.DataBind();

			LoadDDLSection(null, null);
		}

		protected void LoadDDLSection(object p1, EventArgs p2) {
			ddlSection.DataSource = new YearClassSectionTable(db).GetSectionByYearClass(ddlYear.SelectedValue, ddlClass.SelectedValue);
			ddlSection.DataBind();

			LoadNextOfDDLSection(null, null);
		}

		protected void LoadNextOfDDLSection(object o, EventArgs e) {
			LoadDDLTerm(null, null);
			//LoadDDLSubject(null, null);
		}

		protected void LoadDDLTerm(object o, EventArgs e) {
			ddlTerm.DataSource = new TermYearClassSectionTable(db).GetTermByYearClassSection(ddlYear.SelectedValue, ddlClass.SelectedValue, ddlSection.SelectedValue);
			ddlTerm.DataBind();

			LoadGV(null, null);
		}

		protected void LoadDDLSubject(object p1, EventArgs p2) {
			ddlSubject.DataSource = new TeacherSubjectTable(db).GetTeacherSubject(User.Identity.Name,
				new YearClassSectionTable(db).GetYearClassSectionId(ddlYear.SelectedValue, ddlClass.SelectedValue, ddlSection.SelectedValue));
			ddlSubject.DataBind();

			LoadGV(null, null);
		}

		protected void LoadGV(object p1, EventArgs p2) {
			var res = new MarkTable(db).GetTermTabulation(ddlTerm.SelectedValue);
			
			DataTable pivotTable = new DataTable();
			pivotTable.Columns.Add("Position");
			pivotTable.Columns.Add("Roll");
			//roll.AutoIncrement = true;
			//roll.AutoIncrementStep = 1;
			//roll.AutoIncrementSeed = 1;
			pivotTable.Columns.Add("First Name");
			pivotTable.Columns.Add("Last Name");

			Dictionary<string, List<TextValuePair>> subjectMarkPortions = new Dictionary<string, List<TextValuePair>>();

			var teacherSubjects = new TeacherSubjectTable(db).GetTeacherSubject(
				new YearClassSectionTable(db).GetYearClassSectionId(ddlYear.SelectedValue, ddlClass.SelectedValue, ddlSection.SelectedValue));

			foreach (var teacherSubject in teacherSubjects) {
				var portions = new MarkPortionTable(db).GetMarkPortion(teacherSubject.TeacherSubjectId);
				subjectMarkPortions.Add(teacherSubject.TeacherSubjectId, portions);
				headerLength.Add(teacherSubject.Name, portions.Count+1);
				foreach (var portion in portions) {
					pivotTable.Columns.Add(portion.Text + "|" + teacherSubject.TeacherSubjectId);
				}
				pivotTable.Columns.Add("Total|" + teacherSubject.TeacherSubjectId);
			}
			pivotTable.Columns.Add("Grand Total");

			var students = new StudentTable(db).GetStudents(ddlYear.SelectedValue, ddlClass.SelectedValue, ddlSection.SelectedValue);
			var studentMarks = res.GroupBy(x => x.Student.ID).ToList();
			foreach (var student in students) {
				var studentMark = studentMarks.Find(x => x.Key == student.ID);
				var newRow = pivotTable.Rows.Add();
				newRow["Roll"] = student.Roll;
				newRow["First Name"] = student.FirstName;
				newRow["Last Name"] = student.LastName;
				int grandTotal = 0;
				bool termAbsent = true;
				if (studentMark == null) {
					for (int i = 0; i < newRow.ItemArray.Length; i++) {
						newRow.ItemArray[i] = "A";
					}
				} else {
					foreach (var subjectMarkPortion in subjectMarkPortions) {
						int subjectTotal = 0;
						bool subjectAbsent = true;
						foreach (var portion in subjectMarkPortion.Value) {
							try {
								int mark;
								if (int.TryParse(studentMark.Where(x => x.PortionId == portion.Value).First().Mark, out mark) && mark >= 0) {
									newRow[portion.Text + "|" + subjectMarkPortion.Key] = mark;
									subjectTotal += mark;
									subjectAbsent = false;
								} else {
									newRow[portion.Text + "|" + subjectMarkPortion.Key] = "A";
								}
							} catch (Exception ex) {
								newRow[portion.Text + "|" + subjectMarkPortion.Key] = "A";
								Global.LogError(ex);
							}
						}
						if (subjectAbsent)
							newRow["Total|" + subjectMarkPortion.Key] = "A";
						else {
							newRow["Total|" + subjectMarkPortion.Key] = subjectTotal;
							termAbsent = false;
						}
						grandTotal += subjectTotal;
					}
				}
				if (termAbsent)
					newRow["Grand Total"] = "A";
				else
					newRow["Grand Total"] = grandTotal;
			}

			pivotTable.DefaultView.Sort = "Grand Total DESC";
			
			gv.DataSource = pivotTable;
			gv.DataBind();
		}

		protected void gv_RowDataBound(object sender, GridViewRowEventArgs e) {
			if(e.Row.RowType == DataControlRowType.DataRow) {
				e.Row.Cells[0].Text = (e.Row.RowIndex + 1).ToString();
			}
			
			if(e.Row.RowType == DataControlRowType.Header) {
				GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
				HeaderGridRow.CssClass = "text-info";
				//HeaderGridRow.BorderColor = System.Drawing.Color.LightBlue;
				HeaderGridRow.Cells.Add(new TableHeaderCell() { ColumnSpan = 4, BackColor= System.Drawing.Color.White });
				TableHeaderCell HeaderCell;

				foreach (var length in headerLength) {
					HeaderCell = new TableHeaderCell();
					HeaderCell.Text = length.Key;
					HeaderCell.ColumnSpan = length.Value;
					HeaderGridRow.Cells.Add(HeaderCell);
				}
				HeaderGridRow.Cells.Add(new TableHeaderCell() { BackColor = System.Drawing.Color.White });

				gv.Controls[0].Controls.AddAt(0, HeaderGridRow);
				foreach (DataControlFieldHeaderCell cell in e.Row.Cells) {
					cell.Text = cell.Text.Split('|')[0];
				}
			}
		}
	}
}