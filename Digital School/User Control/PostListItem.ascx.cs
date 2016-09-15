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
			get { return heading.InnerText; }
			set { heading.InnerText = value; }
		}

		public string Body {
			get { return body.InnerText; }
			set { body.InnerText = value; }
		}

		public int PostID {
			get { return int.Parse(hf.Value); }
			set { hf.Value = value.ToString(); }
		}

		public string Badge {
			get { return spanBadge.InnerText; }
			set { spanBadge.InnerText = value; }
		}

		public string OnClientClick {
			get { return divCss.OnClientClick; }
			set { divCss.OnClientClick = value; }
		}

		public void SetActive() {
			divCss.Attributes["class"] = "list-group-item active";
		}

		protected void onPostClick(EventArgs e) {
			PostClick?.Invoke(this, e);
		}

		protected void heading_Click(object sender, EventArgs e) {
			onPostClick(new EventArgs());
		}
	}
}