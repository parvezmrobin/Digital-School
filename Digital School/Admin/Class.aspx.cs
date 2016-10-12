using AspNet.Identity.MySQL;
using System;
using System.Collections.Generic;
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
			var res = new YearClassSectionTable(db).GetClassByYear(ddlYear.SelectedValue);

			gvExistingClass.DataSource = res;
			gvExistingClass.DataBind();

			ddlExistingClass.DataSource = res;
			ddlExistingClass.DataBind();

			LoadGVExistingSection(null, null);
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

		protected void LoadGVExistingSection(object o, EventArgs e) {
			gvExistingSection.DataSource = new YearClassSectionTable(db).GetSectionByYearClass(ddlYear.SelectedValue, ddlClass.SelectedValue);

			gvExistingSection.DataBind();
		}

		protected void btnAssignClass_Click(object sender, EventArgs e) {
			if (IsValid) {
				YearClassSectionTable YCSTable = new YearClassSectionTable(db);
				foreach (ListItem item in cbSection.Items) {
					if (item.Selected) {
						//If this class is not existed in selected year
						if (YCSTable.HasYearClassSection(ddlYear.SelectedValue, ddlClass.SelectedValue, item.Value)) {
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

			foreach (ListItem item in cbSection2.Items) {
				if (item.Selected) {
					//If this class is not existed in selected year
					if (YCSTable.HasYearClassSection(ddlYear.SelectedValue, ddlExistingClass.SelectedValue, item.Value)) {
						//If no class exists create a YearClassSection entry
						YCSTable.AddYearClassSection(ddlYear.SelectedValue, ddlExistingClass.SelectedValue, item.Value);
					}
				}
			}

			LoadGVExistingSection(null, null);
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