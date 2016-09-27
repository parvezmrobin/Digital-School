using System;
using System.Web.UI;

namespace Digital_School.Student
{
	public partial class Summary : Page
	{
		protected void Page_Load(object o, EventArgs e) {
			if (!IsPostBack) {
				var res = new AspNet.Identity.MySQL.MySQLDatabase().QueryValue("SELECT due FROM studentview WHERE UserName = '" + User.Identity.Name+"' LIMIT 1", null);
				var due = Convert.ToInt32(res);
				if (due <= 0) {
					pDue.Attributes["class"] = "text-success text-right col-md-4";
					pDue.InnerHtml = "You have no due";
				} else {
					pDue.Attributes["class"] = "text-danger text-right col-md-4";
					pDue.InnerHtml = "You have ৳" + due.ToString() + " due";
				}
			}
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