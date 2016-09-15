using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School.Admin
{
	public partial class SiteData : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e) {

		}

		protected void SummarySlideShow_Click(object obj, EventArgs e) {
			
		}

		protected void SummaryGallery_Click(object obj, EventArgs e) {
			Response.Redirect("~/Admin/Gallery");
		}

		protected void SummaryApplication_Click(object obj, EventArgs e) {
			Response.Redirect("~/Admin/Application");
		}
	}
}