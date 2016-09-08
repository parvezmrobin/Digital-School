using System;

namespace Digital_School.Teacher
{
	public partial class Summary : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e) {
			SummaryInput.Click += delegate { Response.Redirect("~/Teacher/InputResult", true); };
			SummaryNotifications.Click += delegate { Response.Redirect("~/Teacher/NotificationQuest", true); };
			SummaryTransaction.Click += delegate { Response.Redirect("~/Teacher/Transaction", true); };
			SummaryMiscellaneous.Click += delegate { Response.Redirect("~/Teacher/Miscellaneous", true); };
		}
		
	}
}