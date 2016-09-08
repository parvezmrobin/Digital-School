using System;
using System.Web.UI;

namespace Digital_School.Student
{
	public partial class Summary : Page
	{
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