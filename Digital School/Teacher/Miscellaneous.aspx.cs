using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School.Teacher
{
	public partial class Miscellaneous : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e) {
			SummaryPromote.Click += delegate { Response.Redirect("~/Common/Promote", true); };
			SummaryEditStudent.Click += delegate { Response.Redirect("~/Teacher/EditStudent", true); };
			SummaryStudentGroup.Click += delegate { Response.Redirect("~/Teacher/StudentGroup", true); };
            SummaryTabulation.Click += delegate { Response.Redirect("~/Common/Tabulatation", true); };
		}
	}
}