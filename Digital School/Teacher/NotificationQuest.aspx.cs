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

namespace Digital_School.Teacher
{
	public partial class NotificationQuest : System.Web.UI.Page
	{
		//TODO Split page by Notification and Question
		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				LoadTeachers();
			}
			LoadQuests();
		}

		private void LoadQuests() {
			var res = new MySQLDatabase().Query("getQuestionByTUN",
				new Dictionary<string, object>() { { "@TUN", User.Identity.Name } },
				true);
			divQuestions.Controls.Clear();
			foreach (var item in res) {
				PostListItem post = LoadControl("~/User Control/PostListItem.ascx") as PostListItem;
				post.PostID = Convert.ToInt32(item["id"]);
				post.Title = item["title"];
				post.Badge = (item["isAnswered"] == "0" ? "new" : "read");
				post.PostClick += delegate {
					hfQuesId.Value = post.PostID.ToString();
					var res2 = new MySQLDatabase().QueryValue("getQuestionBodyById", new Dictionary<string, object>() { { "@pid", post.PostID } }, true);
					quesBody.InnerText = res2.ToString();
				};
				divQuestions.Controls.Add(post);
			}
		}

		private void LoadTeachers() {
			ddlTo.DataSource = new MySQLDatabase().Query(
				"getGroupByTUN",
				new Dictionary<string, object>() { { "@TUN", User.Identity.Name } },
				true).Select(x => new {
					Text = x["group"],
					Value = x["id"]
				}).ToList();
			ddlTo.DataBind();
		}

		protected void btnPush_Click(object sender, EventArgs e) {
			if (IsValid) {
				MySQLDatabase db = new MySQLDatabase();
				var TUId = Context.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(User.Identity.Name).Id;
				var res1 = db.Query("GetStudentIdByGId",
					new Dictionary<string, object>() {
					{"@GId", ddlTo.SelectedValue }
					}, true);

				var id = db.QueryValue("addNotification",
					new Dictionary<string, object>() {
					{"@TUId", TUId },
					{"@ptitle", txtSubject.Text },
					{"@pbody", txtDetail.Text }
					}, true);

				foreach (var item in res1) {
					db.Execute("addStudentNotification",
						new Dictionary<string, object>() {
						{ "@SId", item["studentId"] },
						{ "@NId", id }
						}, true);
				}
			}
		}

		protected void btnReply_Click(object sender, EventArgs e) {
			var TUId = Context.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(User.Identity.Name).Id;
			MySQLDatabase db = new MySQLDatabase();

			quesBody.InnerText = string.Empty;
			var id = Convert.ToInt32(hfQuesId.Value);
			db.Execute("addQuestionAnswer",
				new Dictionary<string, object>() {
					{"@pid", id },
					{"@panswer", txtAnswer.Text }
				}, true);
			txtAnswer.Text = string.Empty;
			if (Statics.Settings[Statics.NotificationOnAnswer]) {
				//TODO Send notification on ansering question
			}
		}
	}
}