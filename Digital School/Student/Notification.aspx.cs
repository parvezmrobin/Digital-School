using AspNet.Identity.MySQL;
using Digital_School.Models;
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
	public partial class Notification : Page
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

			int? postId = Convert.ToInt32(Request.QueryString["postid"]);
			foreach (var item in res) {
				var noti = LoadControl("~/User Control/PostListItem.ascx") as PostListItem;
				noti.PostID = Convert.ToInt32(item["id"]);
				if (postId != null && postId == noti.PostID)
					noti.SetActive();
				noti.Title = item["title"];
				noti.Badge = (item["isRead"] == "True") ? "read" : "new";
				noti.Body = "- " + item["teacher"];
				noti.PostClick += delegate { Response.Redirect("~/Student/Notification?postid=" + noti.PostID, true); };
				PostList.Controls.Add(noti);
			}

			if (postId == null) {
				postBody.InnerText = string.Empty;
			} else {
				res = db.Query("getNotificationByIdSId",
					new Dictionary<string, object>() {
						{ "@pid", postId },
						{"@SId", studentId }
					}, true);
				if (res.Count > 0) {
					postTitle.InnerText = res[0]["title"];
					postBody.InnerText = res[0]["body"];
					pushedBy.InnerText = "- " + res[0]["teacher"];
				} else {
					Server.Transfer(Statics.Error404, true);
				}
			}
			PostList.Style["min-height"] = postBody.Attributes["height"];
		}

		protected void Unnamed_Click(object sender, EventArgs e) {
			if (Request.QueryString["postid"] == null) {
				return;
			}
			MySQLDatabase db = new MySQLDatabase();
			int id = Convert.ToInt32(Request.QueryString["postid"]);
			var studentId = new UserTable<ApplicationUser>(db).GetUserId(User.Identity.Name);
			db.Execute("removeNotificationByNidSId",
				new Dictionary<string, object>() {
					{"@Nid", id },
					{"@SId",  Convert.ToInt32(db.QueryValue(
						"SELECT id FROM student WHERE userid = '" + studentId + "' LIMIT 1",
						null))}
				}, true);
			Response.Redirect(Request.Url.AbsolutePath);
		}
	}
}