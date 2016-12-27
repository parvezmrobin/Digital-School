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
		protected void Page_Init(object sender, EventArgs e) {
			if (!IsPostBack) {
				LoadDDLTeacher();
				LoadDDLDesignation();
                LoadDDLYear(null, null);
                success1.Visible = false;
				success2.Visible = false;
				info.Visible = false;
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

        protected void LoadDDLYear(object o, EventArgs e)
        {
            MySQLDatabase db = new MySQLDatabase();
            ddlYear.DataSource = new YearTable(db).GetAllYear();
            ddlYear.DataBind();

            LoadDDLClass(null, null);
            LoadDDLToClass(null, null);
          
        }
        protected void LoadDDLClass(object o, EventArgs e)
        {
            MySQLDatabase db = new MySQLDatabase();
            ddlClass.DataSource = new YearClassSectionTable(db).GetClassByYear(ddlYear.SelectedValue);
            ddlClass.DataBind();

            LoadDDLSection(null, null);
        }
        protected void LoadDDLSection(object o, EventArgs e)
        {
            MySQLDatabase db = new MySQLDatabase();
            ddlSection.DataSource = new YearClassSectionTable(db).
                GetSectionByYearClass(ddlYear.SelectedValue, ddlClass.SelectedValue);
            ddlSection.DataBind();

            LoadDDLStudent(null, null);
        }
        protected void LoadDDLStudent(object o,EventArgs e)
        {
            MySQLDatabase db = new MySQLDatabase();
            int value =  new YearClassSectionTable(db).GetYearClassSectionId(ddlYear.SelectedValue, ddlClass.SelectedValue, ddlSection.SelectedValue);
            ddlStudent.DataSource=db.Query("getStudentByYCSId", new Dictionary<string, object>() { { "@YCSId", value } }, true).
                Select(x => new TextValuePair
                {
                    Value = x["studentid"],
                    Text = x["firstname"]+x["lastname"],
                    
                    //Roll = Convert.ToInt32(x["roll"])
                }).ToList();
            //ddlStudent.DataSource = new StudentYearClassSectionRollTable(db).GetStudents(value);
            ddlStudent.DataBind();

            var value2 = new YearClassSectionTable(db).GetYearClassSectionId(ddlYear.SelectedValue, ddlClass.SelectedValue, ddlSection.SelectedValue);
            txtRoll.Text = new StudentYearClassSectionRollTable(db).GetStudentRoll(value2, ddlStudent.SelectedValue).ToString();
        }
        protected void LoadDDLToClass(object o, EventArgs e)
        {
            MySQLDatabase db = new MySQLDatabase();
            ddlToClass.DataSource = new YearClassSectionTable(db).GetClassByYear(ddlYear.SelectedValue);
            ddlToClass.DataBind();
            ddlToClass.SelectedValue = ddlClass.SelectedValue;
            LoadDDLToSection(null, null);
        }
        protected void LoadDDLToSection(object o, EventArgs e)
        {
            MySQLDatabase db = new MySQLDatabase();
            ddlToSection.DataSource = new YearClassSectionTable(db).
                GetSectionByYearClass(ddlYear.SelectedValue, ddlToClass.SelectedValue);
            ddlToSection.DataBind();
            ddlToSection.SelectedValue = ddlSection.SelectedValue;
        }
       
      
        protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySQLDatabase db = new MySQLDatabase();
            //ddlToClass.SelectedIndex = ddlClass.SelectedIndex;
            //ddlToSection.SelectedIndex = ddlSection.SelectedIndex;
            var value = new YearClassSectionTable(db).GetYearClassSectionId(ddlYear.SelectedValue, ddlClass.SelectedValue, ddlSection.SelectedValue);
            txtRoll.Text = new StudentYearClassSectionRollTable(db).GetStudentRoll(value, ddlStudent.SelectedValue).ToString();
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDDLSection(null,null);
            ddlToClass.SelectedValue = ddlClass.SelectedValue;
            LoadDDLToSection(null, null);        
        }

        protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDDLStudent(null, null);
            
            ddlToSection.SelectedValue = ddlSection.SelectedValue;
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDDLClass(null, null);
            LoadDDLToClass(null, null);
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            MySQLDatabase db = new MySQLDatabase();
            new StudentYearClassSectionRollTable(db).updateStudent(new StudentYearClassSectionRollTable(db)
                .GetStudentYearClassSectionRollId(new YearClassSectionTable(db)
                .GetYearClassSectionId(ddlYear.SelectedValue, ddlClass.SelectedValue, ddlSection.SelectedValue), ddlStudent.SelectedValue), new YearClassSectionTable(db)
                .GetYearClassSectionId(ddlYear.SelectedValue, ddlToClass.SelectedValue, ddlToSection.SelectedValue), txtRoll.Text);

        }

    }
}