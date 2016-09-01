using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School
{
	public partial class Album : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				string[] dirs = Directory.GetDirectories(Server.MapPath("~/Albums"));
				foreach (var dir in dirs) {
					User_Control.Album album = LoadControl("~/User Control/Album.ascx") as User_Control.Album;
					album.Name = dir.Substring(dir.LastIndexOf('\\') + 1);

					Row.Controls.Add(album);
				}
			}
		}
	}
}