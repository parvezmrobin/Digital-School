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
	public partial class AnswerQuests : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e) {
			LoadQuests();
		}

		private void LoadQuests() {
			var res = new MySQLDatabase().Query("getQuestionByTUN",
				new Dictionary<string, object>() { { "@TUN", User.Identity.Name } },
				true);
			divQuestions.Controls.Clear();

			int? postId = string.IsNullOrEmpty(Request.QueryString["postid"]) ? (int?)null : Convert.ToInt32(Request.QueryString["postid"]);
			foreach (var item in res) {
				PostListItem post = LoadControl("~/User Control/PostListItem.ascx") as PostListItem;
				post.PostID = Convert.ToInt32(item["id"]);
				if (postId != null && post.PostID == postId)
					post.SetActive();
				post.Title = item["title"];
				post.Badge = (item["isAnswered"] == "0" ? "new" : "read");
				post.Body = "- " + item["askedby"];
				post.PostClick += delegate {
					Response.Redirect(Request.Url.AbsolutePath + "?postid=" + post.PostID);
				};
				divQuestions.Controls.Add(post);
			}
			LoadQuestionDetail(postId);
		}

		private void LoadQuestionDetail(int? postId) {
			if (postId == null)
				return;
			var res2 = new MySQLDatabase().QueryValue("getQuestionBodyById", new Dictionary<string, object>() { { "@pid", postId } }, true);
			quesBody.InnerText = res2.ToString();
			quesBody.Visible = true;
			hAnswered.Visible = false;
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
			quesBody.Visible = false;
			hAnswered.Visible = true;
			if (Statics.Settings[Statics.NotificationOnAnswer]) {
				//TODO Send notification on ansering question
			}
		}
	}
}