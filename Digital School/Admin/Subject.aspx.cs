using AspNet.Identity.MySQL;
using Digital_School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School.Admin
{
	public partial class Subject : System.Web.UI.Page
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

		protected void SelectedYearChanged(object o, EventArgs e) {
			LoadDDLClass(null, null);
			LoadDDLSubject(null, null);
		}

		protected void LoadDDLYear(object o, EventArgs e) {
			ddlYear.DataSource = db.Query("getAllYear", null, true).
				Select(x => new TextValuePair { Text = x["year"], Value = x["yearid"] }).ToList();
			ddlYear.DataBind();

			SelectedYearChanged(null, null);
		}

		protected void LoadDDLClass(object o, EventArgs e) {
			ddlClass.DataSource = db.Query("getClassByYId", new Dictionary<string, object>() { { "@yid", ddlYear.SelectedValue } }, true).
				Select(x => new TextValuePair { Text = x["class"], Value = x["classid"] }).ToList();
			ddlClass.DataBind();

			LoadDDLSection(null, null);
		}

		protected void LoadDDLSection(object o, EventArgs e) {
			var res = db.Query("getSectionByYIdCId",
				new Dictionary<string, object>() {
					{"@YId", ddlYear.SelectedValue },
					{"@CId", ddlClass.SelectedValue }
				}, true).
				Select(x => new TextValuePair { Text = x["section"], Value = x["sectionid"] }).ToList();
			ddlSection.DataSource = res;
			ddlSection.DataBind();

			LoadGVDDLExistingSubject(null, null);
		}

		protected void LoadGVDDLExistingSubject(object o, EventArgs e) {
			var YCSId = db.QueryValue("getYearClassSectionId",
				new Dictionary<string, object>() {
					{"@pyearid", ddlYear.SelectedValue },
					{"@pclassid", ddlClass.SelectedValue },
					{"@psectionid", ddlSection.SelectedValue }
				}, true);

			var res = db.Query("getSubjectByYCSId", new Dictionary<string, object>() {
				{"@YCSId", YCSId }
			}, true);
			gvSubject.DataSource = res.Select(x => new {
				Teacher = x["teacher"],
				SubjectId = x["subjectcode"],
				SubjectName = x["subject"],
				TotalMark = x["totalmark"]
			}).ToList();
			gvSubject.DataBind();

			ddlExistingSubject.DataSource = res.Select(x => new TextValuePair { Text = x["subject"], Value = x["teachersubjectid"] }).ToList();
			ddlExistingSubject.DataBind();

			LoadGVExistingMarkPortion(null, null);
		}

		protected void LoadGVExistingMarkPortion(object o, EventArgs e) {
			gvExistingMarkPortion.DataSource = db.Query("getMarkPortionByTSId", new Dictionary<string, object>() { { "@TSId", ddlExistingSubject.SelectedValue } }, true).
				Select(x => new TextValuePair { Text = x["portionname"], Value = x["percentage"] }).ToList();
			gvExistingMarkPortion.DataBind();
		}

		protected void LoadDDLAllSubject(object o, EventArgs e) {
			ddlAllSubject.DataSource = db.Query("getAllSubject", null, true).
				Select(x => new TextValuePair { Text = x["subject"], Value = x["subjectid"] }).ToList();
			ddlAllSubject.DataBind();
		}

		protected void LoadDDLTeacher(object o, EventArgs e) {
			ddlTeacher.DataSource = db.Query("getAllTeacher", null, true).
				Select(x => new TextValuePair { Text = x["name"], Value = x["id"] }).ToList();
			ddlTeacher.DataBind();
		}

		protected void LoadDDLSubject(object o, EventArgs e) {
			ddlSubject.DataSource = db.Query("getSubjectByYId", new Dictionary<string, object>() { { "@YId", ddlYear.SelectedValue } }, true).
				Select(x => new TextValuePair { Text = x["subject"], Value = x["subjectid"] }).ToList();
			ddlSubject.DataBind();
		}



		protected void LoadGVMarkPortion(object o, EventArgs e) {
			gvMarkPortions.DataSource = db.Query("getAllPortion", null, true).
				Select(x => new TextValuePair { Text = x["portion"], Value = x["portionid"] }).ToList();
			gvMarkPortions.DataBind();
		}

		//protected void LoadDDLExistingSubject(object o, EventArgs e) {

		//	var res = db.Query("getSubjectByYCSId", new Dictionary<string, object>() { {"@YCSId",YCSId } }, true);

		//	ddlExistingSubject.DataSource = res.Select(x => new TextValuePair {
		//		Text = x["subjectid"] + " - " + x["subject"],
		//		Value = x["teachersubjectid"]
		//	}).ToList();
		//	ddlExistingSubject.DataBind();
		//}



		protected void btnAssign_Click(object sender, EventArgs e) {
			var YCSId = db.QueryValue("getYearClassSectionId", new Dictionary<string, object>() {
				{"@pyearid", ddlYear.SelectedValue },
				{"@pclassid", ddlClass.SelectedValue },
				{"@psectionid", ddlSection.SelectedValue }
			}, true);

			var teacherSubjectId = db.QueryValue("addTeacherSubject", new Dictionary<string, object>() {
				{"@TId", ddlTeacher.SelectedValue },
				{"@SId", ddlSubject.SelectedValue },
				{"@YCSId", YCSId }
			}, true);
			foreach (GridViewRow row in gvMarkPortions.Rows) {
				if ((row.FindControl("cbInclude") as CheckBox).Checked) {

					var portionId = Convert.ToInt32((row.FindControl("hfPortionId") as HiddenField).Value);
					var percentage = Convert.ToInt32((row.FindControl("txtPercentage") as TextBox).Text);

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
				db.Execute("INSERT INTO subejctyear VALUES(null, '" + ddlAllSubject.SelectedValue + "', '" + ddlYear.SelectedValue + "', " + txtTotalMark.Text + ");", null);
			}
		}

		//protected void btnCreateSection_ServerClick(object o, EventArgs e) {
		//	db.Execute("INSERT INTO subject VALUES(null, '" + txtSubjectCode.Text + "', '" + txtSubjectName.Text + "');", null);
		//	LoadDDLSubject(null, null);
		//}

		//protected void btnCreatePortion_ServerClick(object o, EventArgs e) {
		//	db.Execute("INSERT INTO portion VALUES(null, '" + txtPortionName.Text + "');", null);
		//	LoadGVMarkPortion(null, null);
		//}


	}
}