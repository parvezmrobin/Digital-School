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
			string dir = Request.QueryString["album"];
			string root = Server.MapPath("~");
			string[] albums = Directory.GetDirectories(root + "/Albums");
			divAlbum.Controls.Clear();
			foreach(var album in albums) {
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
				for(int i = 0; i<images.Length; i++) {
					SelectableImage si = LoadControl("~/User Control/SelectableImage.ascx") as SelectableImage;
					si.WidthClass = "col-md-6";
					si.SelectorClass = "selectorClass";
					si.FilePath = images[i];
					images[i] = "~/" + images[i].Substring(root.Length);
					images[i] = images[i].Replace('\\', '/');
					si.ImageUrL = images[i];
					si.Name = images[i].Split('/').Last();
					divImages.Controls.Add(si);
				}
			}
		}

		protected void btnUpload_Click(object sender, EventArgs e) {

		}

		protected void Unnamed_Click(object sender, EventArgs e) {
			foreach(CheckBox cb in divImages.Controls) {
				if (cb.Checked) {
					string root = cb.ClientID.Substring(cb.ClientID.LastIndexOf("cb"));
					String hf = (from HiddenField h in divImages.Controls where h.ClientID.Contains(root) select h.Value).First();
					Directory.Delete(hf);
				}
			}
		}

		protected void btnRemoveAlbum_Click(object sender, EventArgs e) {
			string dir = Request.QueryString["album"];
			if (dir == null)
				return;
			Directory.Delete(Server.MapPath("~/Albums/" + dir), true);
			Response.Redirect(Request.Url.AbsolutePath);
		}
	}
}