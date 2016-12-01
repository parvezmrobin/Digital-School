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
           
            cbSettings.DataSource = Digital_School.Settings.Setting.Select(x => new {
				Text = x.Key,
				Value = x.Key
			});
			cbSettings.DataBind();
			foreach (ListItem item in cbSettings.Items) {
				item.Selected = Digital_School.Settings.Setting[item.Text];
			}
		}

		protected void Unnamed_Click(object sender, EventArgs e) {
           // string s = null;
			foreach (ListItem item in cbSettings.Items) {
                Digital_School.Settings.Setting[item.Text] = item.Selected;
                //if (item.Selected)
                //{
                //    s = s + "1" + " ";
                //}
                //else
                //{
                //    s = s + "0" + " ";
                //}
			}
            //Statics.JsonWriter(s);
            Digital_School.Settings.WriteXml();
			hSuccess.Visible = true;
		}

	}
}