using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School.User_Control
{
	public partial class Album : System.Web.UI.UserControl
	{
		public string Name {
			get { return name.InnerText; }
			set {
				name.InnerText = value;
				link.HRef = "~/Images.aspx?album=" + value;
			}
		}
		protected void Page_Load(object sender, EventArgs e) {

		}
	}
}