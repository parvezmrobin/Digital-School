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
	public partial class Section : System.Web.UI.Page
	{
		private MySQLDatabase db = new MySQLDatabase();
		protected void Page_Init(object sender, EventArgs e) {
			if (!IsPostBack) {
				LoadDDLYear(null, null);
			}
		}
		protected void Page_LoadComplete(object sender, EventArgs e) {
			if (!IsPostBack) {
				LoadCBLSection(null, null);
			}
		}

		protected void LoadDDLYear(object o, EventArgs e) {
			ddlYear.DataSource = db.Query("getAllYear", null, true).
				Select(x => new TextValuePair { Text = x["year"], Value = x["yearid"] }).ToList();
			ddlYear.DataBind();
			LoadDDLClass(null, null);
		}

		protected void LoadDDLClass(object o, EventArgs e) {
			ddlClass.DataSource = db.Query("getClassByYId", new Dictionary<string, object>() { { "@yid", ddlYear.SelectedValue } }, true).
				Select(x => new TextValuePair { Text = x["class"], Value = x["classid"] }).ToList();
			ddlClass.DataBind();

			LoadGVSection(null, null);
		}

		protected void LoadGVSection(object o, EventArgs e) {
			gvSection.DataSource = db.Query("getSectionByYIdCId",
				new Dictionary<string, object>() {
					{"@YId", ddlYear.SelectedValue },
					{"@CId", ddlClass.SelectedValue }
				}, true).Select(x => new TextValuePair {
					Text = x["section"],
					Value = x["sectionid"]
				}).ToList();

			gvSection.DataBind();
		}

		protected void LoadCBLSection(object o, EventArgs e) {
			cbSection.DataSource = db.Query("getAllSection", null, true).
				Select(x => new TextValuePair { Text = x["section"], Value = x["sectionid"] }).ToList();
			cbSection.DataBind();
		}

		protected void btnAssign_Click(object sender, EventArgs e) {
			//Checks if a YearClassSection entry with null Section exists
			int? nullSectionId = (int?) db.QueryValue("hasNullSection",
						new Dictionary<string, object>() {
							{ "@YId", ddlYear.SelectedValue },
							{ "@CId", ddlClass.SelectedValue }
						}, true);

			foreach (ListItem item in cbSection.Items) {
				if (item.Selected) {
					int count = Convert.ToInt32(db.QueryValue("countSectionInClassYear",
						new Dictionary<string, object>() {
							{ "@YId", ddlYear.SelectedValue },
							{ "@CId", ddlClass.SelectedValue },
							{ "@SId", item.Value }
						}, true));
					if (count > 0)
						continue;

					if(nullSectionId == null) {
						//If no entry with null Section found, add a new entry normally
						db.Execute("addYearClassSection", new Dictionary<string, object>() {
							{"@YId", ddlYear.SelectedValue },
							{"@CId", ddlClass.SelectedValue },
							{"@SId", item.Value }
						}, true);
					} else {
						//If a entry with null section exists, replace that with a section id
						db.Execute("changeSectionId", new Dictionary<string, object>() {
							{"@YCSId", nullSectionId },
							{"@Sid", item.Value }
						}, true);
						//Next sections will be added normally
						nullSectionId = null;
					}
				}
				
			}
			LoadGVSection(null, null);
		}

		//protected void btnCreateSection_ServerClick(object o, EventArgs e) {
		//	if (Convert.ToInt32(db.QueryValue("countSection", new Dictionary<string, object>() { { "@SId", txtLevel.Value } }, true)) > 0)
		//		return;

		//	db.Execute("INSERT INTO section VALUES(" + txtLevel.Value + ", '" + txtLabel.Value + "');", null);
		//	LoadCBLSection(null, null);
		//}
	}
}