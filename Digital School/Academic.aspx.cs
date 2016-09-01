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
			List<Dictionary<string, string>> res = db.Query("getAllApplication", null);

			foreach (var item in res) {
				Tile tile = LoadControl("~/User Control/Tile.ascx") as Tile;
				tile.PostID = Convert.ToInt32(item["id"]);
				tile.Title = item["title"];
				tile.Detail = item["summary"];
				tile.Type = Convert.ToInt32(item["type"]);
				tile.WidthClass = "col-sm-12";

				tile.TitleClick += delegate {
					//Session["postid"] = tile.PostID;
					//Session["type"] = tile.Type;
					Response.Redirect("~/Apply.aspx?postid=" + tile.PostID + "&type=" + tile.Type);
					// TODO Use Notification URL
				};

				Applications.Controls.Add(tile);
			}

			//using (MySqlConnection conn = new MySqlConnection(Statics.ConnectionString)) {
			//	MySqlCommand cmd = new MySqlCommand("getAllApplication", conn);
			//	cmd.CommandType = CommandType.StoredProcedure;
			//	conn.Open();
			//	MySqlDataReader reader = cmd.ExecuteReader();
			//	while (reader.Read()) {
			//		Tile section = LoadControl("~/SectionUserControl.ascx") as Tile;
			//		section.PostID = (int)reader["id"];
			//		section.Title = reader["name"].ToString();
			//		section.Detail = reader["detail"].ToString();
			//		section.Type = (int)reader["type"];
			//		section.WidthClass = "col-sm-12";
			//		section.TitleClick += delegate {
			//			Session["postid"] = section.PostID;
			//			Session["type"] = section.Type;
			//			Response.Redirect("~/Apply.aspx");
			//		};

			//		Applications.Controls.Add(section);
			//	}

			//}
		}
	}
}