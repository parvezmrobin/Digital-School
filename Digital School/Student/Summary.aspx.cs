using AspNet.Identity.MySQL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Digital_School.Student
{
	public partial class Summary : Page
	{
		protected void Page_Load(object o, EventArgs e) {
			if (!IsPostBack) {
				ShowDue();
			}
		}

		private void ShowDue() {
			MySQLDatabase db = new MySQLDatabase();
			var studentId=db.QueryValue("SELECT id from student where userid='"+User.Identity.GetUserId()+"' limit 1",null);
			var debit = db.Query("getDebitBySId", new Dictionary<string, object>() { { "@SId", studentId } }, true);
			var totalDebit = 0;
			foreach (var item in debit) {
				totalDebit += int.Parse(item["amount"]);
			}
			var credit = db.Query("getCreditBySId", new Dictionary<string, object>() { { "@SId", studentId } }, true);
			var totalCredit = 0;
			foreach (var item in credit) {
				totalCredit += int.Parse(item["amount"]);

			}
			if (totalCredit >= totalDebit) {
				btnDue.Text = "Payment Due: "+(totalCredit - totalDebit).ToString();
				btnDue.CssClass = "text-danger";
			} else {
				btnDue.Text = "Payment Advance: " + (totalDebit - totalCredit).ToString();
				btnDue.CssClass = "text-success";
			}

			Session["debit"] = debit;
			Session["credit"] = credit;
		}

		protected void SummaryNotification_Click(object sender, EventArgs e) {
			Response.Redirect("~/Student/Notification.aspx");
		}

		protected void SummaryBrowse_Click(object sender, EventArgs e) {
			Response.Redirect("~/Student/BrowseMarks.aspx");
		}

		protected void SummaryGraphicalView_Click(object sender, EventArgs e) {
			Response.Redirect("~/Student/GraphicalView.aspx");
		}

		protected void SummaryAskQuestion_Click(object sender, EventArgs e) {
			Response.Redirect("~/Student/AskQuestion.aspx");
		}
	}
}