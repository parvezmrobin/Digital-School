using AspNet.Identity.MySQL;
using Digital_School.User_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School.Admin
{
	public partial class Application : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
			var res = db.Query("getAllApplication", null, true);
			var appid = Request.QueryString["appid"];
			foreach (var item in res) {
				PostListItem post = LoadControl("~/User Control/PostListItem.ascx") as PostListItem;
				post.PostID = Convert.ToInt32(item["id"]);
				if (item["id"] == appid)
					post.SetActive();
				post.Title = item["title"];
				if (item["type"] == "1") {
					post.Badge = "stu";
					post.CssClass += " stu";
				} else {
					post.Badge = "tea";
					post.CssClass += " tea";
				}
				post.Body = item["date"];
				post.PostClick += delegate { Response.Redirect(Request.Url.AbsolutePath + "?appid=" + post.PostID); };

				Applications.Controls.Add(post);
			}

			if(appid != null) {
				var res2 = db.Query("getResponseByAId",
					new Dictionary<string, object>() { { "@AId", Convert.ToInt32(appid) } },
					true);
				foreach (var item in res2) {
					PostListItem post = LoadControl("~/User Control/PostListItem.ascx") as PostListItem;
					post.PostID = Convert.ToInt32(item["id"]);
					post.Title = item["name"];
					post.Body = item["email"];
					post.PostClick += delegate { Response.Redirect("~/Admin/Response?resid="+post.PostID); };

					Responses.Controls.Add(post);
				}
			}
		}
	}
}