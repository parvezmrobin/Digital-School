using AspNet.Identity.MySQL;
using Digital_School.User_Control;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School.Student
{
	public partial class Notification : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();
				PostList.Controls.Clear();
				var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
				var studentId = Convert.ToInt32(db.QueryValue(
					"SELECT id FROM student WHERE userid = '"
					+ manager.FindByName(User.Identity.Name).Id
					+ "' LIMIT 1",
					null));

				var res = db.Query("getNotificationByStudentId",
					new Dictionary<string, object>() { { "@pid", studentId } },
					true);

				foreach (var item in res) {
					var noti = LoadControl("~/User Control/PostListItem.ascx") as PostListItem;
					noti.PostID = Convert.ToInt32(item["id"]);
					noti.Title = item["title"];
					noti.PostClick += delegate { Response.Redirect("~/Student/Notification?postid=" + noti.PostID, true); };
					PostList.Controls.Add(noti);
				}
			
			if (Request.QueryString["postid"] == null) {
				postBody.InnerText = string.Empty;
			} else {
				res = db.Query("getNotificationById",
					new Dictionary<string, object>() { { "@pid", Convert.ToInt32(Request.QueryString["postid"]) } },
					true);
				if (res.Count > 0) {
					postTitle.InnerText = res[0]["title"];
					postBody.InnerText = res[0]["body"];
				} else {
					Response.Redirect(Statics.Error404, true);
				}
			}
			PostList.Style["min-height"] = postBody.Attributes["height"];
		}
	}
}