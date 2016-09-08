using AspNet.Identity.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School
{
	public partial class Teachers : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				MySQLDatabase db = new MySQLDatabase();
				List<Dictionary<string, string>> res = db.Query("SELECT firstname, lastname, subject FROM teacher", null);
				//TODO load teacher list
				gvDetail.DataSource = res;
				gvDetail.DataBind();

			}
		}

		protected void gvName_SelectedIndexChanged(object sender, EventArgs e) {

		}
	}
}