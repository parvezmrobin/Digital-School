using System;

namespace Digital_School.Teacher
{
	public partial class Summary : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e) {
			SummaryAttendance.Click += delegate { Response.Redirect("~/Teacher/Attendance"); };
			SummaryInput.Click += delegate { Response.Redirect("~/Teacher/InputResult", true); };
			SummaryNotifications.Click += delegate { Response.Redirect("~/Teacher/Notification", true); };
			SummaryAnswer.Click += delegate { Response.Redirect("~/Teacher/AnswerQuests"); };
			SummaryTransaction.Click += delegate { Response.Redirect("~/Teacher/Transaction", true); };
			SummaryMiscellaneous.Click += delegate { Response.Redirect("~/Teacher/Miscellaneous", true); };
		}
		
	}
}