using System;

namespace Digital_School.User_Control
{
	public partial class Summary : System.Web.UI.UserControl
	{
		public event EventHandler Click;

		public string Title {
			get { return heading.InnerText; }
			set { heading.InnerText = value; }
		}
		public string Detail {
			get {
				return detail.InnerHtml;
			}
			set {
				detail.InnerHtml = value;
			}
		}

		public string WidthClass {
			get { return widthdiv.Attributes["class"]; }
			set { widthdiv.Attributes["class"] = value; }
		}

		public string PostBackUrl {
			get { return anchor.HRef; }
			set { anchor.HRef = value; }
		}

		public string PanelClass {
			get { return panel.Attributes["class"]; }
			set { panel.Attributes["class"] = value; }
		}

		protected void onClick(EventArgs e) {
			Click?.Invoke(this, e);
		}

		protected void button_Click(object sender, EventArgs e) {
			onClick(new EventArgs());
		}
	}
}