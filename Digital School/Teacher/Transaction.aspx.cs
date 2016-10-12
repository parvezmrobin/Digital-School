using AspNet.Identity.MySQL;
using Digital_School.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School.Teacher
{
	public partial class Transaction : System.Web.UI.Page
	{
		public string Date { get; internal set; }

		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				InitDDL();
				//hSuccess.Visible = false;
			}
		}

		private void InitDDL() {
			//TODO Change Seleciton According to TeacherTransactionAccessibility Table
			LoadClass(null, null);
			ddlType.DataSource = new MySQLDatabase().
				Query("getAllTransactionType", null, true).
				Select(x => new { Text = x["name"], Value = x["id"] }).ToList();
			ddlType.DataBind();

			//LoadClassDue(null, null);
		}

		protected void LoadClass(object o, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			var yid = db.QueryValue("getYearId", new Dictionary<string, object>() { { "@pyear", DateTime.Now.Year } }, true);
			ddlClass.DataSource = db.Query("getTransactableClassByTUIdYId",
				new Dictionary<string, object>() {
					{"@TUId", User.Identity.GetUserId() },
					{"@YId", yid }
				}, true).Select(x => new TextValuePair {
					Text = x["class"],
					Value = x["classid"]
				}).ToList();
			ddlClass.DataBind();
			LoadSection(null, null);
		}

		/*protected void LoadClassDue(object o, EventArgs e) {
			ddlClassDue.DataSource = getClasses();
			ddlClassDue.DataBind();
			LoadSectionDue(null, null);
		}*/


		protected void LoadSection(object o, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			var yid = db.QueryValue("getYearId", new Dictionary<string, object>() { { "@pyear", DateTime.Now.Year } }, true);
			ddlSection.DataSource = db.Query("getTransactableSectionByTUIdYIdCId",
				new Dictionary<string, object>() {
					{"@TUId", User.Identity.GetUserId() },
					{"@YId", yid },
					{"@Cid", ddlClass.SelectedValue }
				}, true).Select(x => new TextValuePair {
					Text = x["section"],
					Value = x["sectionid"]
				}).ToList();
			ddlSection.DataBind();
			LoadStudent(null, null);
		}

		//protected void LoadSectionDue(object o, EventArgs e) {
		//	ddlSectionDue.DataSource = getSections();
		//	ddlSectionDue.DataBind();
		//	LoadCBL(null, null);
		//}

		protected void LoadStudent(object o, EventArgs e) {
			ddlStudent.DataSource = getStudents();
			ddlStudent.DataBind();
			LoadDue(null, null);
		}

		//protected void LoadCBL(object o, EventArgs e) {
		//	MySQLDatabase db = new MySQLDatabase();
		//	var yid = db.QueryValue("getYearId", new Dictionary<string, object>() { { "@pyear", DateTime.Now.Year } }, true);
		//	var ycsId = db.QueryValue("getYearClassSectionId",
		//		new Dictionary<string, object>() {
		//			{"@pyearid", yid },
		//			{"@pclassid", ddlClass.SelectedValue },
		//			{"@psectionid", ddlSection.SelectedValue }
		//		}, true);
		//	cblDue.DataSource = db.Query("getStudentByTUNYCSId",
		//		new Dictionary<string, object>() {
		//			{"@TUN", User.Identity.Name},
		//			{"@YCSId", ycsId },
		//			{"@pdue", Convert.ToInt32(txtDueGreaterThen.Text.Length==0?"0":txtDueGreaterThen.Text) }
		//		}, true).Select(x => new TextValuePair {
		//			Text = x["student"],
		//			Value = x["studentid"]
		//		}).ToList();
		//	cblDue.DataBind();
		//}

		private List<TextValuePair> getStudents() {
			MySQLDatabase db = new MySQLDatabase();
			var yid = db.QueryValue("getYearId", new Dictionary<string, object>() { { "@pyear", DateTime.Now.Year } }, true);
			var ycsId = db.QueryValue("getYearClassSectionId",
				new Dictionary<string, object>() {
					{"@pyearid", yid },
					{"@pclassid", ddlClass.SelectedValue },
					{"@psectionid", ddlSection.SelectedValue }
				}, true);
			return db.Query("getStudentByTUNYCSId",
				new Dictionary<string, object>() {
					{"@TUN", User.Identity.Name},
					{"@YCSId", ycsId }
				}, true).Select(x => new TextValuePair {
					Text = x["student"],
					Value = x["studentid"]
				}).ToList();
		}
		protected void LoadDue(object o, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			var debit = db.Query("getDebitBySId", new Dictionary<string, object>() { { "@SId", ddlStudent.SelectedValue } }, true);
			var totalDebit = 0;
			foreach (var item in debit) {
				totalDebit += int.Parse(item["amount"]);
			}
			var credit = db.Query("getCreditBySId", new Dictionary<string, object>() { { "@SId", ddlStudent.SelectedValue } }, true);
			var totalCredit = 0;
			foreach (var item in credit) {
				totalCredit += int.Parse(item["amount"]);

			}
			if (totalCredit >= totalDebit) {
				lblDue.Text = "Due";
				lblDue.CssClass = "col-md-3 control-label text-danger";
				btnDue.Text = (totalCredit - totalDebit).ToString();
				btnDue.CssClass = "form-control text-danger";
			} else {
				lblDue.Text = "Advance";
				lblDue.CssClass = "col-md-3 control-label text-success";
				btnDue.Text =(totalDebit - totalCredit).ToString();
				btnDue.CssClass = "form-control text-successs";
			}

			Session["debit"] = debit;
			Session["credit"] = credit;

		}

		protected void btnPay_Click(object sender, EventArgs e) {

			MySQLDatabase db = new MySQLDatabase();
			db.Execute("addTransaction",
				new Dictionary<string, object>() {
					{"@SId", ddlStudent.SelectedValue },
					{"@TeaId", db.QueryValue("getTIdByTUN", new Dictionary<string, object>() { { "@TUN", User.Identity.Name } }, true) },
					{"@TypeId", ddlType.SelectedValue },
					{"@ammount", Convert.ToInt32(txtAmount.Text) }
				}, true);
			LoadDue(null, null);
		}

		//protected void btnNotify_Click(object sender, EventArgs e) {
		//	var id = new MySQLDatabase().QueryValue("addNotification",
		//		new Dictionary<string, object>() {
		//			{"@TUId", User.Identity.GetUserId() },
		//			{"@ptitle", "Notification on Due" },
		//			{"@pbody", "You have not paid your due since a while. We believe its by a mistake. " +
		//			"Please check you summary page to know the ammount of you due and pay it as fast as possible" }
		//		}, true);

		//	foreach (ListItem item in cblDue.Items) {
		//		if (item.Selected) {
		//			new MySQLDatabase().Execute("addStudentNotification",
		//				new Dictionary<string, object>() {
		//					{"@Sid", item.Value }   ,
		//					{"Nid", id }
		//				}, true);
		//		}
		//	}
		//	//hSuccess.Visible = true;
		//}
	}
}