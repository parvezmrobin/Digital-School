using AspNet.Identity.MySQL;
using Digital_School.User_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School
{
	public partial class About : Page
	{
		protected void Page_Load(object sender, EventArgs e) {

			MySQLDatabase db = new MySQLDatabase();
			List<Dictionary<string, string>> res = db.Query("getAllSpeechSummary", null);

			foreach(var item in res) {
				Tile tile = LoadControl("~/User Control/Tile.ascx") as Tile;
				tile.PostID = Convert.ToInt32(item["id"]);
				tile.Title = item["name"];
				tile.Detail = item["detail"];
				tile.Type = Convert.ToInt32(item["type"]);
				tile.WidthClass = "col-sm-12";

				tile.TitleClick += delegate {
					Session["postid"] = tile.PostID;
					Session["type"] = tile.Type;
					Response.Redirect("~/Post.aspx");
				};

				speeches.Controls.Add(tile);
			}

			
		}

	}
}