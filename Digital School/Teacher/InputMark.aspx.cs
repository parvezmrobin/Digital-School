using AspNet.Identity.MySQL;
using Digital_School.Models;
using Digital_School.User_Control;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School.Teacher {
	public partial class InputMark : Page {
		protected void Page_Init(object sender, EventArgs e) {			
			if (!IsPostBack) {
				LoadYear(null, null);
			}
		}

		protected void LoadYear(object obj, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			var teacherId = Context.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(User.Identity.Name).Id;
			var res = db.Query(
				"getYearByTUId",
				new Dictionary<string, object>() { { "@TUId", teacherId } },
				true);
			ddlYear.Items.Clear();
			foreach (var item in res) {
				ddlYear.Items.Add(new ListItem(item["year"], item["yearid"]));
			}
			LoadClass(null, null);
		}

		protected void LoadClass(object obj, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			var teacherId = Context.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(User.Identity.Name).Id;
			ddlClass.DataSource = db.Query(
				"getClassByTUIdYId",
				new Dictionary<string, object>() {
						{ "@TUId", teacherId },
						{ "@YId", ddlYear.SelectedValue } },
				true)
				.Select(x => new {
					Text = x["class"],
					Value = x["classid"]
				}).ToList();
			ddlClass.DataTextField = "Text";
			ddlClass.DataValueField = "Value";
			ddlClass.DataBind();
			LoadSection(null, null);
		}

		protected void LoadSection(object obj, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			var teacherId = Context.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(User.Identity.Name).Id;
			ddlSection.DataSource = db.Query(
				"getSectionByTUIdYIdCId",
				new Dictionary<string, object>() {
						{"@TUId", teacherId },
						{"@YId", ddlYear.SelectedValue },
						{"@CId", ddlClass.SelectedValue }
				}, true)
				.Select(x => new {
					Text = x["section"],
					Value = x["sectionid"]
				}).ToList();
			ddlSection.DataTextField = "Text";
			ddlSection.DataValueField = "Value";
			ddlSection.DataBind();
			ReloadYCSId(null, null);
		}
		protected void ReloadYCSId(object obj, EventArgs ea) {
			ViewState["YCSId"] = Convert.ToInt32(new MySQLDatabase().QueryValue(
					"getYearClassSectionId",
					new Dictionary<string, object>() {
						{"@pyearid", ddlYear.SelectedValue },
						{"@pclassid", ddlClass.SelectedValue },
						{"@psectionid", ddlSection.SelectedValue } },
					true));
			LoadSubject(null, null);
		}

		protected void LoadSubject(object obj, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			var teacherId = Context.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(User.Identity.Name).Id;
			ddlSubject.DataSource = db.Query(
					"getSubjectByTUIdYCSId",
					new Dictionary<string, object>() {
						{"@TUId", teacherId },
						{"@YCSId", ViewState["YCSId"] } },
					true)
					.Select(x => new {
						Text = x["subject"],
						Value = x["id"]
					}).ToList();
			ddlSubject.DataTextField = "Text";
			ddlSubject.DataValueField = "Value";
			ddlSubject.DataBind();
			ddlSubject.Items.Insert(0, new ListItem("All", "all"));
			LoadStudent(null, null);
		}

		protected void LoadStudent(object o, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			var teacherId = Context.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(User.Identity.Name).Id;
			if (ddlSubject.SelectedValue == "all") {
				ddlStudent.DataSource = db.Query(
					"getStudentByTUNYCSId",
					new Dictionary<string, object>() {
						{"@TUN",User.Identity.Name },
						{"@ycsid",ViewState["YCSId"] }
				},
					true).Select(x => new {
						Text = x["student"],
						Value = x["studentid"]
					}).ToList();
				ddlStudent.DataTextField = "Text";
				ddlStudent.DataValueField = "Value";
				ddlStudent.DataBind();
			} else {
				ddlStudent.DataSource = db.Query(
					"getStudentByTUNYCSIdSId",
					new Dictionary<string, object>() {
						{"@TUN", User.Identity.Name },
						{"@YCSId", ViewState["YCSId"] },
						{"@SId", ddlSubject.SelectedValue }
					},
					true).Select(x => new {
						Text = x["student"],
						Value = x["studentid"]
					}).ToList();
				ddlStudent.DataTextField = "Text";
				ddlStudent.DataValueField = "Value";
				ddlStudent.DataBind();
			}

			BindGridView(null, null);
		}
		protected void Page_LoadComplete(object sender, EventArgs e) {
			if (!IsPostBack) {
				//BindGridView(null, null);
			}
        }

        protected void BindGridView(object o, EventArgs e) {
            if (ViewState["YCSId"] == null)
                ReloadYCSId(null, null);

            MySQLDatabase db = new MySQLDatabase();
            var teacherId = new UserTable<ApplicationUser>(db).GetUserId(User.Identity.Name);
            List<Dictionary<string, string>> res2;
            if (ddlSubject.SelectedValue == "all") {
                res2 = db.Query("getMarkPortionByYCSId", new Dictionary<string, object>() { { "@YCSId", ViewState["YCSId"] } }, true);
            } else {
                res2 = db.Query("getMarkPortionByTSId", new Dictionary<string, object>() { { "@TSId", ddlSubject.SelectedValue } }, true);
            }
            var query = from x in res2
                        let v = db.Query("getMarkByMPIdSIdTid",
                            new Dictionary<string, object>() {
                                {"@MPId", x["markportionid"] },
                                {"@SId", ddlStudent.SelectedValue },
                                {"@Tid", ddlTerm.SelectedValue }
                            }, true)
                        select new {
							Subject = (v.Count == 0) ? null : v[0]["subject"],
							PortionName = x["portionname"],
                            MarkPortionId = x["markportionid"],
                            Mark = (v.Count == 0) ? null : v[0]["mark"],
                            MarkId = (v.Count == 0) ? null : v[0]["markid"]
                        };

            gvMark.DataSource = query.ToList();
            gvMark.DataBind();
        }

        protected bool IsInEditMode {

            get { if (ViewState["editMode"] == null) {
                    ViewState["editMode"] = false;
                    return false;
                } else {
                    return (bool) ViewState["editMode"];
                }
            }
            set { ViewState["editMode"] = value; }

        }

		protected void btnSubmit_Click(object sender, EventArgs e) {
			if((sender as Button).Text == "Edit") {
				(sender as Button).Text = "Update";
				List<bool> isEditable = new List<bool>(gvMark.Rows.Count);
				foreach(GridViewRow row in gvMark.Rows) {
					if(row.RowType == DataControlRowType.DataRow) {
						bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;

					}
				}
			}
		}
	}
}