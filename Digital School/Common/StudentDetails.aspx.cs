using AspNet.Identity.MySQL;
using Digital_School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School.Common
{
    public partial class StudentDetails : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDDLYear(null, null);
            }
        }
        protected void LoadDDLYear(object o, EventArgs e)
        {
            MySQLDatabase db = new MySQLDatabase();
            ddlYear.DataSource = new YearTable(db).GetAllYear();
            ddlYear.DataBind();

            LoadDDLClass(null, null);
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

            LoadGVStudentDetails(null, null);

        }
        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDDLClass(null, null);
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDDLSection(null, null);
        }

        protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGVStudentDetails(null, null);
        }
        protected void LoadGVStudentDetails(object sender,EventArgs e)
        {
            MySQLDatabase db = new MySQLDatabase();
            gvStudentDetails.DataSource = new StudentYearClassSectionRollTable(db)
                .GetStudents(new YearClassSectionTable(db)
                .GetYearClassSectionId(ddlYear.SelectedValue, ddlClass.SelectedValue, ddlSection.SelectedValue))
                .Select(x => new
                {
                    Student = x,
                    User = new UserTable<ApplicationUser>(db).GetUserById(x.UserId)
                })
                .Select(x => new
                {
					Roll = x.Student.Roll,
                    Name = x.Student.FullName,
                    FathersName = x.User.FathersName,
                    MothersName = x.User.MothersName,
                    Email = x.User.Email,
                    PhoneNumber = x.User.PhoneNumber,
                    Gender = x.User.Gender

                });
            gvStudentDetails.DataBind();
        }
    }
}