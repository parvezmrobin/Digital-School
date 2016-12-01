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
	public partial class Class : System.Web.UI.Page
	{
		private MySQLDatabase db = new MySQLDatabase();
		
		protected void Page_Init(object sender, EventArgs e) {
			if (!IsPostBack) {
				LoadDDLYear(null, null);
				LoadDDLClass(null, null);
				LoadCBLSection(null, null);
			}
		}

		protected void Page_LoadComplete(object obj, EventArgs e) {
			if (!IsPostBack) {
				LoadGVDDLExistingClass(null, null);
			}
		}

		protected void LoadDDLYear(object o, EventArgs e) {
			ddlYear.DataSource = new YearTable(db).GetAllYear();
			ddlYear.DataBind();
		}

		protected void LoadGVDDLExistingClass(object obj, EventArgs e) {
			if (ddlYear.Items.Count > 0) {
				var res = new YearClassSectionTable(db).GetClassByYear(ddlYear.SelectedValue);

				gvExistingClass.DataSource = res;
				gvExistingClass.DataBind();

				ddlExistingClass.DataSource = res;
				ddlExistingClass.DataBind();
			} else {
				gvExistingClass.DataSource = new DataTable();
				gvExistingClass.DataBind();
				ddlExistingClass.Items.Clear();
			}
			LoadGVExistingSection(null, null);
		}

		protected void LoadGVExistingSection(object o, EventArgs e) {
			if (ddlExistingClass.Items.Count > 0) {
                gvExistingSection.Columns[0].Visible = true;
				gvExistingSection.DataSource = new YearClassSectionTable(db).GetSectionByYearClass(ddlYear.SelectedValue, ddlExistingClass.SelectedValue);
				gvExistingSection.DataBind();
                gvExistingSection.Columns[0].Visible = false;
            } else {
                gvExistingSection.Columns[0].Visible = true;
                gvExistingSection.DataSource = new DataTable();
				gvExistingSection.DataBind();
                gvExistingSection.Columns[0].Visible = false;
            }
        
		}
		protected void LoadDDLClass(object o, EventArgs e) {
			ddlClass.DataSource = new ClassTable(db).GetAllClass();
			ddlClass.DataBind();
		}

		protected void LoadCBLSection(object o, EventArgs e) {
			var res = new SectionTable(db).GetAllSection();
			cbSection.DataSource = res;
			cbSection.DataBind();

			cbSection2.DataSource = res;
			cbSection2.DataBind();
		}

		
		protected void btnAssignClass_Click(object sender, EventArgs e) {
			if (IsValid) {
				YearClassSectionTable YCSTable = new YearClassSectionTable(db);
				foreach (ListItem item in cbSection.Items) {
					if (item.Selected) {
						//If this class is not existed in selected year
						if (!YCSTable.HasYearClassSection(ddlYear.SelectedValue, ddlClass.SelectedValue, item.Value)) {
							//If no class exists create a YearClassSection entry
							YCSTable.AddYearClassSection(ddlYear.SelectedValue, ddlClass.SelectedValue, item.Value);
						}
					}
				}
				LoadGVDDLExistingClass(null, null);
				LoadGVExistingSection(null, null);
			}
		}

		protected void btnAssignSection_Click(object sender, EventArgs e) {
			YearClassSectionTable YCSTable = new YearClassSectionTable(db);
			//YCSTable.RemoveClassFromYear(ddlYear.SelectedValue, ddlClass.SelectedValue);
			foreach (ListItem item in cbSection2.Items) {
				if (item.Selected) {
					//If this class is not existed in selected year
					if (!YCSTable.HasYearClassSection(ddlYear.SelectedValue, ddlExistingClass.SelectedValue, item.Value)) {
						//If no class exists create a YearClassSection entry
						YCSTable.AddYearClassSection(ddlYear.SelectedValue, ddlExistingClass.SelectedValue, item.Value);
					}

				}
			}

			LoadGVExistingSection(null, null);
		}


        protected void gvExistingSection_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var sectionId = gvExistingSection.Rows[e.RowIndex].Cells[0].Text;
          //  int key=Convert.ToInt32(gvExistingSection.DataKeys[e.RowIndex].Value.ToString());
            YearClassSectionTable YCSTable = new YearClassSectionTable(db);
            YCSTable.RemoveSectionFromYCSId(ddlYear.SelectedValue, ddlExistingClass.SelectedValue,Convert.ToInt32(sectionId));
            
            LoadGVExistingSection(null, null);
        }

        protected void gvExistingClass_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var classId = gvExistingClass.Rows[e.RowIndex].Cells[0].Text;
            YearClassSectionTable YCSTable = new YearClassSectionTable(db);
            YCSTable.RemoveClassFromYear(ddlYear.SelectedValue, ddlExistingClass.SelectedValue);
            LoadGVDDLExistingClass(null, null);
        }

        //protected void Unnamed_ServerValidate(object source, ServerValidateEventArgs args) {
        //	args.IsValid = false;
        //	foreach (ListItem item in cbSection.Items) {
        //		if (item.Selected) {
        //			args.IsValid = true;
        //			break;
        //		}
        //	}
        //}

        //protected void btnCreateClass_ServerClick(object o, EventArgs e) {
        //	if (string.IsNullOrEmpty(txtLabel.Text) || string.IsNullOrEmpty(txtLevel.Text))
        //		return;

        //	//If no class exists with this value
        //	if(Convert.ToInt32(db.QueryValue("countClass", new Dictionary<string, object>() { { "@CId", Convert.ToInt32(txtLevel.Text) } }, true)) == 0) {
        //		db.Execute("Insert INTO class VALUES(" + txtLevel.Text + ", '" + txtLabel.Text + "');", null);
        //	}

        //	LoadCheckBoxList(null, null);
        //}
    }
}