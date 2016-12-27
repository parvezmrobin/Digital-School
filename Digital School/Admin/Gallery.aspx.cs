using Digital_School.User_Control;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School.Admin
{
	public partial class Gallery : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e) {
			LoadAlbum();
			divImage.Visible = Request.QueryString["album"] != null;
		}

		void LoadAlbum() {
			string dir = Request.QueryString["album"];
			string root = Server.MapPath("~");
			string[] albums = Directory.GetDirectories(root + "/Albums");
			divAlbum.Controls.Clear();
			foreach (var album in albums) {
				PostListItem post = LoadControl("~/User Control/PostListItem.ascx") as PostListItem;
				post.Title = album.Split('\\').Last();
				post.PostClick += delegate { Response.Redirect("~/Admin/Gallery?album=" + post.Title); };
				if (dir != null && dir == post.Title)
					post.SetActive();
				divAlbum.Controls.Add(post);
			}
		}

		protected void Page_LoadComplete(object obj, EventArgs e) {
			string root = Server.MapPath("~");
			string dir = Request.QueryString["album"];
			divImages.Controls.Clear();
			if (dir != null) {
				string[] images = Directory.GetFiles(root + "Albums/" + dir);
				string str = "";
				for(int i = 0; i<images.Length; i++) {
					//SelectableImage si = LoadControl("~/User Control/SelectableImage.ascx") as SelectableImage;
					//si.WidthClass = "col-md-6";
					//si.SelectorClass = "selectorClass";
					//si.FilePath = images[i];
					images[i] = "../" + images[i].Substring(root.Length);
					images[i] = images[i].Replace('\\', '/');
					//si.ImageUrL = images[i];
					//si.Name = images[i].Split('/').Last();
					//divImages.Controls.Add(si);
					str += "<div class='col-md-4 col-sm-6'><img src='" + images[i] + "' class='img-thumbnail'/></div>";
				}
				divImages.InnerHtml = str;
			}
		}

		protected void btnUpload_Click(object sender, EventArgs e) {
			if (Request.QueryString["album"] == null)
				Response.Redirect(Statics.Error);
			if (fuImages.HasFile) {
				var files = fuImages.PostedFiles.ToList();
				foreach (var file in files) {
					file.SaveAs(Server.MapPath("~") + "/Albums/" + Request.QueryString["album"] + "/" + file.FileName);
				}
				Page_LoadComplete(null, null);
			}
		}

		protected void btnRemoveAlbum_Click(object sender, EventArgs e) {
			string dir = Request.QueryString["album"];
			if (dir == null)
				return;
			Directory.Delete(Server.MapPath("~/Albums/" + dir), true);
			Response.Redirect(Request.Url.AbsolutePath);
		}

		protected void btnCreateAlbum_Click(object sender, EventArgs e) {
			if(!Directory.Exists(Server.MapPath("~") + "/Albums/" + txtNewAlbum.Text)) {
				Directory.CreateDirectory(Server.MapPath("~") + "/Albums/" + txtNewAlbum.Text);
				LoadAlbum();
			}
		}
	}
}