using System;

namespace Digital_School.User_Control
{
	public partial class SelectableImage : System.Web.UI.UserControl
	{
		public string ImageUrL {
			get { return img.Src; }
			set { img.Src = value; }
		}

		public bool Checked {
			get { return cb.Checked; }
			set { cb.Checked = value; }
		}

		public string SelectorClass {
			get { return cb.CssClass; }
			set { cb.CssClass = value; }
		}

		public string Name {
			get { return cb.Text; }
			set { cb.Text = value; }
		}

		public bool AutoPostBack {
			get { return cb.AutoPostBack; }
			set { cb.AutoPostBack = value; }
		}

		public string FilePath {
			get { return fileName.Value; }
			set { fileName.Value = value; }
		}

		public string WidthClass {
			get { return div.Attributes["class"]; }
			set { div.Attributes["class"] = value; }
		}
		
	}
}