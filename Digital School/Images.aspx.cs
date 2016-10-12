using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School
{
	public partial class Images : Page
	{
		protected void Page_Load(object sender, EventArgs e) {
			if (Request.QueryString["album"] != null) {
				Page.Title = Request.QueryString["album"];
				ViewState["album"] = Page.Title;
			} else if (ViewState["album"] != null) {
				Page.Title = ViewState["album"].ToString();
			}

			if (!IsPostBack) {
				LoadAlbum();
			}

			if (Session["img"] == null) {
				LoadAlbum();
			}
		}

		private void LoadAlbum() {
			string[] imgs;
			if (Request.QueryString["album"] != null) {
				imgs = Directory.GetFiles(Server.MapPath("~/Albums/" + Request.QueryString["album"]));
			} else {
				string firstAlbum = Directory.GetDirectories(Server.MapPath("~/Albums/"))[0];
				Page.Title = new DirectoryInfo(firstAlbum).Name;
				ViewState["album"] = Page.Title;
				imgs = Directory.GetFiles(firstAlbum);
			}

			string root = Server.MapPath("~");
			for (int i = 0; i < imgs.Length; i++) {
				imgs[i] = "~/" + imgs[i].Substring(root.Length);
				imgs[i] = imgs[i].Replace('\\', '/');
			}

			Session["img"] = imgs;
			Session["imgindex"] = 0;
			image.Src = imgs[0];
		}

		protected void btnPrev_Click(object sender, EventArgs e) {
			if (Session["img"] == null) {
				LoadAlbum();
			} else {
				string[] imgs = (string[])Session["img"];
				int index = (int)Session["imgindex"];
				int nindex = index > 0 ? index - 1 : imgs.Length - 1;
				Session["imgindex"] = nindex;
				image.Src = imgs[nindex];
			}
		}

		protected void btnNext_Click(object sender, EventArgs e) {
			if (Session["img"] == null) {
				LoadAlbum();
			} else {
				string[] imgs = (string[])Session["img"];
				int index = (int)Session["imgindex"];
				int nindex = index < imgs.Length - 1 ? index + 1 : 0;
				Session["imgindex"] = nindex;
				image.Src = imgs[nindex];
			}
		}
	}
}