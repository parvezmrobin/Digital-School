using AspNet.Identity.MySQL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School.Admin
{
	public partial class Subject : Page
	{
		private MySQLDatabase db = new MySQLDatabase();
		protected void Page_LoadComplete(object sender, EventArgs e) {
			if (!IsPostBack) {
				//LoadGVSubject(null, null);
				LoadGVMarkPortion(null, null);
			}
		}

		protected void Page_Init(object sender, EventArgs e) {
			if (!IsPostBack) {
				LoadDDLYear(null, null);

				LoadDDLTeacher(null, null);

				LoadDDLAllSubject(null, null);
			}
		}

		protected void LoadDDLYear(object o, EventArgs e) {
			ddlYear.DataSource = new YearTable(db).GetAllYear();
			ddlYear.DataBind();

			SelectedYearChanged(null, null);
		}
		protected void SelectedYearChanged(object o, EventArgs e) {
			LoadDDLClass(null, null);
			LoadDDLSubject(null, null);
		}

		protected void LoadDDLClass(object o, EventArgs e) {
			if (ddlYear.Items.Count > 0) {
				ddlClass.DataSource = new YearClassSectionTable(db).GetClassByYear(ddlYear.SelectedValue);
				ddlClass.DataBind();
			} else {
				ddlClass.Items.Clear();
			}

			LoadDDLSection(null, null);
		}

		protected void LoadDDLSection(object o, EventArgs e) {
			if (ddlClass.Items.Count > 0) {
				ddlSection.DataSource = new YearClassSectionTable(db).GetSectionByYearClass(ddlYear.SelectedValue, ddlClass.SelectedValue);
				ddlSection.DataBind();
			} else {
				ddlSection.Items.Clear();
			}

			LoadGVDDLExistingSubject(null, null);
		}

		protected void LoadGVDDLExistingSubject(object o, EventArgs e) {
			if (ddlSection.Items.Count > 0) {
				var YCSId = new YearClassSectionTable(db).GetYearClassSectionId(ddlYear.SelectedValue, ddlClass.SelectedValue, ddlSection.SelectedValue);
                gvSubject.Columns[0].Visible = true;
                var res = new TeacherSubjectTable(db).GetTeacherSubject(YCSId);
                gvSubject.DataSource = res.Select(x => new {
                    Teacher = x.Teacher.FullName,
                    SubjectId = x.SubjectCode,
                    SubjectName = x.Name,
                    TotalMark = x.TotalMark,
                    TSId = x.TeacherSubjectId
				}).ToList();
				gvSubject.DataBind();

				ddlExistingSubject.DataSource = res.Select(x => new TextValuePair { Text = x.Name, Value = x.TeacherSubjectId }).ToList();
				ddlExistingSubject.DataBind();
                gvSubject.Columns[0].Visible = false;
            } else {
                gvSubject.Columns[0].Visible = true;
                gvSubject.DataSource = new DataTable();
				gvSubject.DataBind();
				ddlExistingSubject.Items.Clear();
                gvSubject.Columns[0].Visible = true;
            }
			LoadGVExistingMarkPortion(null, null);
		}

		protected void LoadGVExistingMarkPortion(object o, EventArgs e) {
			if (ddlExistingSubject.Items.Count > 0) {
                gvExistingMarkPortion.Columns[2].Visible = true;
                gvExistingMarkPortion.DataSource =
                    //new MarkPortionTable(db).GetMarkPortionPercentage(ddlExistingSubject.SelectedValue);
                db.Query("getMarkPortionByTSId", new Dictionary<string, object>() { { "@TSId", ddlExistingSubject.SelectedValue } }, true).
 Select(x => new { Text = x["portionname"], Value = x["percentage"], Id = x["markportionid"] }).ToList();
                gvExistingMarkPortion.DataBind();
                gvExistingMarkPortion.Columns[2].Visible = false;
            } else {
                gvExistingMarkPortion.Columns[2].Visible = true;
                gvExistingMarkPortion.DataSource = new DataTable();
				gvExistingMarkPortion.DataBind();
                gvExistingMarkPortion.Columns[2].Visible = false;
            }
		}

		protected void LoadDDLAllSubject(object o, EventArgs e) {
			ddlAllSubject.DataSource = db.Query("getAllSubject", null, true).
				Select(x => new TextValuePair { Text = x["subject"], Value = x["subjectid"] }).ToList();
			ddlAllSubject.DataBind();
		}

		protected void LoadDDLTeacher(object o, EventArgs e) {
			ddlTeacher.DataSource = new TeacherTable(db).GetAllTeacher().Select(x => new TextValuePair { Text = x.FirstName + " " + x.LastName, Value = x.ID.ToString() }).ToList();
			ddlTeacher.DataBind();
		}

		protected void LoadDDLSubject(object o, EventArgs e) {
			if (ddlYear.Items.Count > 0) {
				ddlSubject.DataSource = new SubjectYearTable(db).GetSubject(ddlYear.SelectedValue).
					Select(x => new TextValuePair { Text = x.ToString(), Value = x.ID }).ToList();
				ddlSubject.DataBind();
			} else {
				ddlSubject.Items.Clear();
			}
		}

		protected void LoadGVMarkPortion(object o, EventArgs e) {
			gvMarkPortions.DataSource = db.Query("getAllPortion", null, true).
				Select(x => new TextValuePair { Text = x["portion"], Value = x["portionid"] }).ToList();
			gvMarkPortions.DataBind();
		}

		protected void btnAssign_Click(object sender, EventArgs e) {
			var YCSId = new YearClassSectionTable(db).GetYearClassSectionId(ddlYear.SelectedValue, ddlClass.SelectedValue, ddlSection.SelectedValue);

			TeacherSubjectTable TSTable = new TeacherSubjectTable(db);
			TSTable.RemoveTeacherSubject(ddlTeacher.SelectedValue, ddlSubject.SelectedValue, YCSId);
			var teacherSubjectId = TSTable.AddTeacherSubject(ddlTeacher.SelectedValue, ddlSubject.SelectedValue, YCSId);

			foreach (GridViewRow row in gvMarkPortions.Rows) {
				if ((row.FindControl("cbInclude") as CheckBox).Checked) {
					string strPerrcent;
					if (string.IsNullOrEmpty(strPerrcent = (row.FindControl("txtPercentage") as TextBox).Text))
						continue;
					var portionId = Convert.ToInt32((row.FindControl("hfPortionId") as HiddenField).Value);
					var percentage = Convert.ToInt32(strPerrcent);

					db.Execute("addMarkPortion", new Dictionary<string, object>() {
						{"@TSId", teacherSubjectId },
						{"@PId", portionId },
						{"@Percentage", percentage }
					}, true);

				}
			}

			LoadGVDDLExistingSubject(null, null);
		}

		protected void btnAddSubjectYear_Click(object sender, EventArgs e) {
			if (IsValid) {
				SubjectYearTable SYTable = new SubjectYearTable(db);
				if (!SYTable.HasSubject(ddlAllSubject.SelectedValue, ddlYear.SelectedValue)) {
					SYTable.AddSubjectYear(ddlAllSubject.SelectedValue, ddlYear.SelectedValue, txtTotalMark.Text);
					LoadDDLSubject(null, null);
				}
			}
		}

        protected void gvExistingMarkPortion_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            var markPortionId=gvExistingMarkPortion.Rows[e.RowIndex].Cells[2].Text;
            //var markPortionId= Convert.ToInt32((e.Values[FindControl("hfPortionId")] as HiddenField).Value);

            // int key = Convert.ToInt32(gvExistingMarkPortion.DataKeys[e.RowIndex].Value.ToString());
            MarkPortionTable MPTable = new MarkPortionTable(db);
            MPTable.RemoveMarkPortionFromSubject(Convert.ToInt32(markPortionId));

            LoadGVDDLExistingSubject(null, null);
        }

        protected void gvSubject_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var teacherSubjectId = gvSubject.Rows[e.RowIndex].Cells[0].Text;
            TeacherSubjectTable TSTable = new TeacherSubjectTable(db);
            TSTable.RemoveTeacherSubject(teacherSubjectId);
            LoadGVDDLExistingSubject(null, null);
        }
    }
}