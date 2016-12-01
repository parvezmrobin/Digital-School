using AspNet.Identity.MySQL;
using Digital_School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace Digital_School.Admin
{
	public partial class Account : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				LoadDDLTeacher();
				LoadDDLDesignation();
				success1.Visible = false;
				success2.Visible = false;
				info.Visible = false;
				//LoadStudentDDL();
			}
			
		}

		


		private void LoadDDLTeacher() {
			MySQLDatabase db = new MySQLDatabase();
			ddlTeacher.DataSource = new TeacherTable(db).GetAllTeacher().Select(x => new TextValuePair { Text = x.FullName, Value = x.ID.ToString() }).ToList();
			ddlTeacher.DataBind();
		}

		private void LoadDDLDesignation() {
			MySQLDatabase db = new MySQLDatabase();
			ddlDesignation.DataSource = db.Query("getAllDesignation", null, true).Select(x => new { Text = x["designation"], Value = x["id"] }).ToList();
			ddlDesignation.DataBind();

			ChangeDDLDesignationAsDDLTeacher(null, null);
		}

		protected void ChangeDDLDesignationAsDDLTeacher(object obj, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			ddlDesignation.SelectedValue = db.QueryValue(
				"getDesignationIdByTId",
				new Dictionary<string, object>() { { "TId", ddlTeacher.SelectedValue } },
				true).ToString();
		}

		protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e) {
			//changeDesignation
			MySQLDatabase db = new MySQLDatabase();
			db.Execute("changeDesignation",
				new Dictionary<string, object>() {
					{"@designationId", ddlDesignation.SelectedValue },
					{"@TId", ddlTeacher.SelectedValue }
				}, true);
			success1.Visible = true;
			
		}
	}
}