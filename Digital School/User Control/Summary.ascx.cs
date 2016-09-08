using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School.User_Control
{
	public partial class Summary : System.Web.UI.UserControl
	{
		public event EventHandler Click;

		public string Title {
			get { return button.Text; }
			set { button.Text = value; }
		}
		public string Detail {
			get {
				return detail.InnerText;
			}
			set {
				detail.InnerText = value;
			}
		}

		public string WidthClass {
			get { return widthdiv.Attributes["class"]; }
			set { widthdiv.Attributes["class"] = value; }
		}

		protected void onClick(EventArgs e) {
			Click?.Invoke(this, e);
		}

		protected void button_Click(object sender, EventArgs e) {
			onClick(new EventArgs());
		}
	}
}