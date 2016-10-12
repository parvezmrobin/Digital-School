using AspNet.Identity.MySQL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School.Teacher
{
	public partial class TransactionHistory : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				MySQLDatabase db = new MySQLDatabase();

				if (Session["debit"] == null || Session["credit"] == null)
					Server.Transfer(Statics.Error404, true);
					var debit=Session["debit"] as List<Dictionary<string, string>>;
				gvDebit.DataSource = debit.
					Select(x => new Models.Transaction() {
						Date = x["date"],
						Amount = int.Parse(x["amount"]),
						TransactionType = x["TranssactionType"],
						DoneBy = x["DoneBy"]
					}).ToList();
				gvDebit.DataBind();
				var credit =Session["credit"] as List<Dictionary<String, String>>;
				gvCredit.DataSource = credit.
					Select(x => new  Models.Transaction() {
						Date = x["date"],
						Amount = int.Parse(x["amount"]),
						TransactionType = x["TransactionType"]
					}).ToList();
				gvCredit.DataBind();

			}

		}
	}
}