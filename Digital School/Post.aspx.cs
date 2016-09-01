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
	public partial class Post : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e) {

			MySQLDatabase db = new MySQLDatabase();
			if (Request.QueryString["posttype"] != null) {
				ddlCatagory.SelectedValue = Request.QueryString["posttype"].ToString();
			}// else if(Request.QueryString["postid"] != null) {
			//	Dictionary<string, object> dict = new Dictionary<string, object>(1);
			//	dict.Add("@pid", Convert.ToInt32(Request.QueryString["postid"]));
			//	ddlCatagory.SelectedValue = db.QueryValue("getTypeById", dict).ToString();
			//}

			LoadPostsAccordingToDDL();

			#region Load Post Detail
			if (Request.QueryString["postid"] != null) {
				Dictionary<string, object> dict = new Dictionary<string, object>(1);
				dict.Add("@pid", Convert.ToInt64(Request.QueryString["postid"]));
				List<Dictionary<string, string>> res = db.Query("getPostById", dict);
				if(res.Count != 0) {
					postTitle.InnerText = res[0]["title"];
					postBody.InnerText = res[0]["body"];
					Page.Title = res[0]["title"];
				} else {
					Response.Redirect("~/Error.html");
				}				
			} else
				LoadFirstPostFromList();
			#endregion

			PostList.Style["max-height"] = postBody.Attributes["height"];
		}

		private void LoadPostsAccordingToDDL() {
			MySQLDatabase db = new MySQLDatabase();
			List<Dictionary<string, string>> res = null;
			if(ddlCatagory.SelectedValue == "All") {
				res = db.Query("getAllIdTitle", null);
			} else {
				Dictionary<string, object> dict = new Dictionary<string, object>(1);
				dict.Add("@ptype", int.Parse(ddlCatagory.SelectedValue));
				res = db.Query("getIdTitleByType", dict);
			}

			PostList.Controls.Clear();

			foreach(var item in res) {
				PostListItem post = LoadControl("~/User Control/PostListItem.ascx") as PostListItem;
				post.Title = item["title"];
				post.PostID = Convert.ToInt32(item["id"]);
				post.PostClick += delegate {
					Response.Redirect(Request.Url.AbsoluteUri + "?postid=" + item["id"], true);
				};
				PostList.Controls.Add(post);
			}
			
		}

		private void LoadFirstPostFromList() {
			//ListBox1.SelectedIndex = 0;

			int? postId = null;
			foreach (var child in PostList.Controls) {
				if (child is PostListItem) {
					postId = (child as PostListItem).PostID;
					break;
				}
			}
			if (postId != null) {
				Response.Redirect(Request.Url.AbsoluteUri + "?postid=" + postId, true);
			} else
				Response.Redirect("~/Error.html", true);
		}

		protected void ddlCatagory_SelectedIndexChanged(object sender, EventArgs e) {
			Response.Redirect(Request.Url.AbsolutePath);
		}		
	}
}