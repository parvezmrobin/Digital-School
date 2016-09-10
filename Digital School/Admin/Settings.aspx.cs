using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School.Admin
{
	public partial class Settings : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e) {
			ScriptManager.RegisterStartupScript(
				up,
				this.GetType(),
				"StartupScript",
				"$(document).ready(function () {$('#hSuccess').delay(5000).fadeOut(1000);});",
				true);

			if (!IsPostBack) {
				PopulateCB();
				hSuccess.Visible = false;
			}
		}

		private void PopulateCB() {
			cbSettings.DataSource = Statics.Settings.Select(x => new {
				Text = x.Key,
				Value = x.Key
			});
			cbSettings.DataBind();
			foreach (ListItem item in cbSettings.Items) {
				item.Selected = Statics.Settings[item.Text];
			}
		}

		protected void Unnamed_Click(object sender, EventArgs e) {
			foreach (ListItem item in cbSettings.Items) {
				Statics.Settings[item.Text] = item.Selected;
			}
			hSuccess.Visible = true;
		}

	}
}