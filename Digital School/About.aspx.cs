using AspNet.Identity.MySQL;
using Digital_School.User_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Digital_School
{
	public partial class About : Page
	{
		protected void Page_Load(object sender, EventArgs e) {

			MySQLDatabase db = new MySQLDatabase();
			List<Dictionary<string, string>> res = db.Query("getAllSpeechSummary", null, true);

			foreach(var item in res) {
				Tile tile = LoadControl("~/User Control/Tile.ascx") as Tile;
				tile.PostID = Convert.ToInt32(item["id"]);
				tile.Title = item["title"];
				tile.Detail = item["summary"];
				tile.Type = 3;
				tile.WidthClass = "col-sm-12";

				tile.TitleClick += delegate {
					Response.Redirect("~/Post.aspx?postid=" + tile.PostID + "&posttype=3");
				};

				speeches.Controls.Add(tile);
			}

			if (!IsPostBack) {
				//TODO Load History from Xml
			}
		}

	}
}