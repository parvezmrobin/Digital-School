using System;

namespace Digital_School.User_Control
{
	public partial class PostListItem : System.Web.UI.UserControl
	{
		public event EventHandler PostClick;

		public string CssClass {
			get { return divCss.Attributes["class"]; }
			set { divCss.Attributes["class"] = value; }
		}

		public string Title {
			get { return heading.Text; }
			set { heading.Text = value; }
		}

		public int PostID {
			get { return int.Parse(hf.Value); }
			set { hf.Value = value.ToString(); }
		}

		public string Badge {
			get { return spanBadge.InnerText; }
			set { spanBadge.InnerText = value; }
		}

		protected void onPostClick(EventArgs e) {
			PostClick?.Invoke(this, e);
		}

		protected void heading_Click(object sender, EventArgs e) {
			onPostClick(new EventArgs());
		}


	}
}