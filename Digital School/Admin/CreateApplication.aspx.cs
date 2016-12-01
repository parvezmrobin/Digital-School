using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School.Admin
{
	public partial class CreateApplication : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e) {

		}

		protected void Unnamed_Click(object sender, EventArgs e) {
			new AspNet.Identity.MySQL.MySQLDatabase().Execute("addApplication",
				new Dictionary<string, object>() {
					{"@title", txtTitle.Text },
					{"@summary", txtSummary.Text },
					{"@url", txtNoticeURL.Text },
					{"@type", ddlType.SelectedValue }
				}, true);
		}
	}
}