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
	public partial class Term : System.Web.UI.Page
	{
		private MySQLDatabase db = new MySQLDatabase();
		protected void Page_Init(object sender, EventArgs e) {
			if (!IsPostBack) {
				LoadDDLYear(null, null);
			}
		}

		protected void Page_LoadComplete(object o, EventArgs e) {
			if (!IsPostBack) {
				LoadGVTerm(null, null);
				LoadGVAddTerm(null, null);
			}
		}

		protected void LoadDDLYear(object o, EventArgs e) {
			ddlYear.DataSource = new YearTable(db).GetAllYear();
			ddlYear.DataBind();

			LoadDDLClass(null, null);
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

			LoadGVTerm(null, null);
		}

		protected void LoadGVTerm(object o, EventArgs e) {
			if (ddlSection.Items.Count > 0) {
                gvTerm.Columns[0].Visible = true;
                //new TermYearClassSectionTable(db).GetTermPercentageByYearClassSection(ddlYear.SelectedValue, ddlClass.SelectedValue, ddlSection.SelectedValue);
                gvTerm.DataSource = 
                db.Query("getTermByYCSId", new Dictionary<string, object>() { { "@YCSId", new YearClassSectionTable(db).GetYearClassSectionId(ddlYear.SelectedValue, ddlClass.SelectedValue, ddlSection.SelectedValue) } }, true).
                Select(x => new 
                {
                    Text = x["term"],
                    Value = x["percentage"],
                    Id=x["id"]
                }).ToList();
            } else {
                gvTerm.Columns[0].Visible = true;
                gvTerm.DataSource = new DataTable();
			}
			gvTerm.DataBind();
            gvTerm.Columns[0].Visible = false;
        }

		protected void LoadGVAddTerm(object o, EventArgs e) {
			gvAddTerm.DataSource = new TermTable(db).GetAllTerm();
			gvAddTerm.DataBind();
		}

		protected void btnAddTerm_Click(object sender, EventArgs e) {
			TermYearClassSectionTable termTable = new TermYearClassSectionTable(db);
			var YCSId = new YearClassSectionTable(db).GetYearClassSectionId(ddlYear.SelectedValue, ddlClass.SelectedValue, ddlSection.SelectedValue);
            //termTable.RemoveTermByYearClassSection(YCSId);
            foreach (GridViewRow row in gvAddTerm.Rows) {
				if ((row.FindControl("cb") as CheckBox).Checked) {
					var percentage = (row.FindControl("txt") as TextBox).Text;
					if (string.IsNullOrEmpty(percentage))
						continue;
					var termId = (row.FindControl("hf") as HiddenField).Value;
                    bool alreadyExsist = Convert.ToInt32(termTable.CheckTermByTermId(termId)) == 0;
                    if (alreadyExsist){
                        termTable.AddTermYearClassSection(termId, YCSId.ToString(), percentage);
                    }
				}
			}

			LoadGVTerm(null, null);
		}

        protected void gvTerm_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var termId = gvTerm.Rows[e.RowIndex].Cells[0].Text;
            TermYearClassSectionTable termTable = new TermYearClassSectionTable(db);
            termTable.RemoveTermByTYCSId(Convert.ToInt32(termId));
            //var markPortionId= Convert.ToInt32((e.Values[FindControl("hfPortionId")] as HiddenField).Value);

            // int key = Convert.ToInt32(gvExistingMarkPortion.DataKeys[e.RowIndex].Value.ToString());

            LoadGVTerm(null, null);
        }
    }
}