using AspNet.Identity.MySQL;
using Digital_School.User_Control;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School
{
	public partial class Academic : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			List<Dictionary<string, string>> res = db.Query("getAllApplication", null, true);

			foreach (var item in res) {
				Tile tile = LoadControl("~/User Control/Tile.ascx") as Tile;
				tile.PostID = Convert.ToInt32(item["id"]);
				tile.Title = item["title"];
				tile.Detail = item["summary"];
				tile.Type = Convert.ToInt32(item["type"]);
				tile.WidthClass = "col-sm-12";

				tile.TitleClick += delegate {
					Response.Redirect("~/Apply.aspx?appid=" + tile.PostID + "&type=" + tile.Type);
				};

				Applications.Controls.Add(tile);
			}
			
		}
	}
}