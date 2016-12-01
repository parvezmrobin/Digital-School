using AspNet.Identity.MySQL;
using Digital_School.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace Digital_School.Teacher
{
	public partial class Mark : System.Web.UI.Page
	{
		private MySQLDatabase db = new MySQLDatabase();
		private List<TextValuePair> portions = null;

		protected void Page_Init(object sender, EventArgs e) {
			if (!IsPostBack) {
				LoadDDLClass(null, null);
			}
		}

		protected void Page_LoadComplete(object obj, EventArgs e) {
			LoadGridView(null, null);
		}

		protected void LoadDDLClass(object sndr, EventArgs e) {
			ddlClass.DataSource = new TeacherSubjectTable(db).GetClass(User.Identity.GetUserId(), new YearTable(db).GetYearId(DateTime.Now.Year));
			ddlClass.DataBind();

			LoadDDLSection(null, null);
		}

		protected void LoadDDLSection(object sndr, EventArgs e) {
			ddlSecion.DataSource = new TeacherSubjectTable(db).GetSection(
				User.Identity.GetUserId(),
				new YearTable(db).GetYearId(DateTime.Now.Year),
				Convert.ToInt32(ddlClass.SelectedValue));

			ddlSecion.DataBind();

			LoadNextOfDDLSection(null, null);
		}

		protected void LoadNextOfDDLSection(object obj, EventArgs e) {
			LoadDDLTerm(null, null);
			LoadDDLSubject(null, null);
			//LoadDDLStudent(null, null);
		}

		protected void LoadDDLTerm(object sndr, EventArgs e) {
			var YCSId = new YearClassSectionTable(db).GetYearClassSectionId(
				new YearTable(db).GetYearId(DateTime.Now.Year).ToString(),
				ddlClass.SelectedValue,
				ddlSecion.SelectedValue);

			ddlTerm.DataSource = new TermYearClassSectionTable(db).GetTermByYearClassSection(YCSId);
			ddlTerm.DataBind();
		}

		protected void LoadDDLSubject(object sndr, EventArgs e) {
			var YCSId = new YearClassSectionTable(db).GetYearClassSectionId(
				new YearTable(db).GetYearId(DateTime.Now.Year).ToString(),
				ddlClass.SelectedValue,
				ddlSecion.SelectedValue);

			ddlSubject.DataSource = new TeacherSubjectTable(db).GetTeacherSubject(User.Identity.Name, YCSId);
			ddlSubject.DataBind();
		}

		//protected void LoadDDLStudent(object sndr, EventArgs e) {
		//	var YCSId = new YearClassSectionTable(db).GetYearClassSectionId(
		//		new YearTable(db).GetYearId(DateTime.Now.Year),
		//		ddlClass.SelectedValue,
		//		ddlSecion.SelectedValue);

		//	ddlStudent.DataSource = new TeacherSubjectTable(db).GetStudent(User.Identity.Name, YCSId)
		//		.Select(x => new TextValuePair { Text = x.Roll + ". " + x.FullName, Value = x.ID.ToString() }).ToList();

		//	ddlStudent.DataBind();
		//	ddlStudent.Items.Insert(0, new ListItem("All", "all"));
		//}

		protected void LoadGridView(Object obj, EventArgs e) {
			var YCSId = new YearClassSectionTable(db).GetYearClassSectionId(
				new YearTable(db).GetYearId(DateTime.Now.Year),
				ddlClass.SelectedValue,
				ddlSecion.SelectedValue);
			var markTable = new MarkTable(db);
			var dataSource = markTable.GetMark(ddlSubject.SelectedValue, ddlTerm.SelectedValue);

			portions = new MarkPortionTable(db).GetMarkPortion(ddlSubject.SelectedValue);

			var pivotTable = new DataTable();
			pivotTable.Columns.Add("Student", typeof(string));
			pivotTable.Columns.Add("StudentId", typeof(int));
			foreach (var pn in portions) {
				pivotTable.Columns.Add(pn.Text, typeof(string));
				pivotTable.Columns.Add(pn.Text + "id", typeof(string));
			}

			//var students = dataSource.GroupBy(x => x["studentid"]).ToList();
			var students = dataSource.GroupBy(x => x.Student.ID).ToList();
			List<TextValuePair> studentFromDDL = new List<TextValuePair>();
			//List<AspNet.Identity.MySQL.Student> studentFromDDL = new List<AspNet.Identity.MySQL.Student>();
			foreach (var item in new TeacherSubjectTable(db).GetStudent(ddlSubject.SelectedValue)) {
				studentFromDDL.Add(new TextValuePair() { Text = item.ToString(), Value = item.ID.ToString() });
			}
			//if (ddlStudent.SelectedValue == "all") {

			//} else {
			//	studentFromDDL.Add(new TextValuePair() { Text = ddlStudent.SelectedItem.Text, Value = ddlStudent.SelectedValue });
			//}
			foreach (var student in studentFromDDL) {
				DataRow newRow = pivotTable.Rows.Add();
				newRow["Student"] = student.Text;
				newRow["StudentId"] = student.Value;
				//try {
				//	var studentGroup = students.Where(x => x.Key == student.Value).ToList()[0];
				//	foreach (var row in studentGroup) {
				//		//newRow[row["portionname"]] = row["mark"];
				//		//newRow[row["portionname"] + "id"] = row["markid"];
				//		try {
				//			newRow[row.PortionName] = row.Mark;
				//			newRow[row.PortionName + "id"] = row.MarkId;
				//		} catch (Exception) {
				//			newRow[row.PortionName] = "NULL";
				//			newRow[row.PortionName + "id"] = row.PortionId;
				//		}
				//	}
				//} catch (Exception ex) {
				//	foreach (var portion in portions) {
				//		newRow[portion.Text] = "NULL";
				//		newRow[portion.Text + "id"] = portion.Value;
				//	}
				//}

				try {
					var studentGroup = students.Where(x => x.Key == student.Value).ToList()[0];
					foreach (var portion in portions) {
						var studentMark = studentGroup.Where(x => x.PortionName == portion.Text).FirstOrDefault();
						if (studentMark == null) {
							newRow[portion.Text] = "NULL";
							newRow[portion.Text + "id"] = portion.Value;
						} else {
							newRow[portion.Text] = studentMark.Mark;
							newRow[portion.Text + "id"] = studentMark.MarkId;
						}
					}
				} catch (Exception) {
					foreach (var portion in portions) {
						newRow[portion.Text] = "NULL";
						newRow[portion.Text + "id"] = portion.Value;
					}
				}
			}
			gvMark.Columns.Clear();

			TemplateField tfStd = new TemplateField();
			tfStd.HeaderText = "Student";
			gvMark.Columns.Add(tfStd);
			foreach (var pn in portions) {
				TemplateField tf = new TemplateField();
				tf.HeaderText = pn.Text;
				gvMark.Columns.Add(tf);
			}
			gvMark.DataSource = pivotTable;
			gvMark.DataBind();
		}

		protected void LoadGV(object e, EventArgs o) {
			var YCSId = new YearClassSectionTable(db).GetYearClassSectionId(
				new YearTable(db).GetYearId(DateTime.Now.Year),
				ddlClass.SelectedValue,
				ddlSecion.SelectedValue);

			var students = new TeacherSubjectTable(db).GetStudent(ddlSubject.SelectedValue);
			var portions = new MarkPortionTable(db).GetMarkPortion(ddlSubject.SelectedValue);

			DataTable table = new DataTable();
			table.Columns.Add("Student");
			table.Columns.Add("StudentId");
			foreach (var portion in portions) {
				table.Columns.Add(portion.Text);
				table.Columns.Add(portion.Value);
			}
			MarkTable markTable = new MarkTable(db);
			foreach (var student in students) {
				var row = table.Rows.Add();
				foreach (var portion in portions) {
					var mark = markTable.GetMark(student.RollYearClassSectionId, ddlTerm.SelectedValue, portion.Value);
					if(mark == null) {
						row[portion.Text] = "NULL";
						row[portion.Value] = portion.Value;
					} else {
						row[portion.Text] = mark.Text;
						row[portion.Value] = mark.Value;
					}
				}
			}
		}

		protected void gvMark_RowDataBound(object sender, GridViewRowEventArgs e) {
			if (e.Row.RowType == DataControlRowType.DataRow) {
				Label label = new Label();
				label.Text = (e.Row.DataItem as DataRowView).Row["Student"].ToString();
				label.CssClass = "control-label";
				e.Row.Cells[0].Controls.Add(label);
				HiddenField hfStd = new HiddenField();
				hfStd.Value = (e.Row.DataItem as DataRowView).Row["StudentId"].ToString();
				e.Row.Cells[0].Controls.Add(hfStd);

				for (int i = 0; i < portions.Count; i++) {
					TextBox textbox = new TextBox();
					textbox.TextMode = TextBoxMode.Number;
					textbox.Attributes["min"] = "0";
					textbox.CssClass = "form-control";
					textbox.Text = (e.Row.DataItem as DataRowView).Row[portions[i].Text].ToString();
					e.Row.Cells[i + 1].Controls.Add(textbox);
					HiddenField hf = new HiddenField();
					hf.Value = (e.Row.DataItem as DataRowView).Row[portions[i].Text + "id"].ToString();
					e.Row.Cells[i + 1].Controls.Add(hf);
				}
			}
		}
	}
}