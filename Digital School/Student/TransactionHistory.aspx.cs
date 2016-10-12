using AspNet.Identity.MySQL;
using Digital_School.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School.Student
{
	public partial class TransactionHistory : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				MySQLDatabase db = new MySQLDatabase();
				var studentid = db.QueryValue("Select id from student where userid='" + User.Identity.GetUserId() + "' limit 1", null);
				var debit = (Session["debit"] == null) ?
					db.Query("getDebitbySId", new Dictionary<string, object>() { { "@SId", studentid } }, true) :
					Session["debit"] as List<Dictionary<string, string>>;
				gvDebit.DataSource = debit.
					Select(x => new Transaction() {
						Date = x["date"],
						Amount = int.Parse(x["amount"]),
						TransactionType = x["TranssactionType"],
						DoneBy = x["DoneBy"]
					}).ToList();
				gvDebit.DataBind();
				var credit = (Session["credit"] == null) ?
					 db.Query("getCreditBySId", new Dictionary<string, object>() { { "@SId", studentid } }, true) :
					 Session["credit"] as List<Dictionary<String, String>>;
				gvCredit.DataSource =credit.
					Select(x => new Transaction() {
						Date = x["date"],
						Amount = int.Parse(x["amount"]),
						TransactionType = x["TransactionType"]
					}).ToList();
				gvCredit.DataBind();

			}

		}
	}
}