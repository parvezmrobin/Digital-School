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
    public partial class EditPost : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {

            MySQLDatabase db = new MySQLDatabase();
            if (Request.QueryString["posttype"] != null)
            {
                ddlCatagory.SelectedValue = Request.QueryString["posttype"].ToString();
            }

            LoadPostsAccordingToDDL();

            #region Load Post Detail
            if (Request.QueryString["postid"] != null)
            {
                LoadPost(Convert.ToInt32(Request.QueryString["postid"]));
				btnAdd.Visible = true;
            }
            else {
				btnEdit.Text = "Add New";
				btnAdd.Visible = false;

            }
            #endregion

            PostList.Style["max-height"] = postBody.Attributes["height"];
        }

        private void LoadPostsAccordingToDDL()
        {
            MySQLDatabase db = new MySQLDatabase();
            List<Dictionary<string, string>> res = null;
            if (ddlCatagory.SelectedValue == "All")
            {
                res = db.Query("getAllIdTitle", null, true);
            }
            else {
                Dictionary<string, object> dict = new Dictionary<string, object>(1);
                dict.Add("@ptype", int.Parse(ddlCatagory.SelectedValue));
                res = db.Query("getIdTitleByType", dict, true);
            }

            PostList.Controls.Clear();
            int? postId = Convert.ToInt32(Request.QueryString["postid"]);
            foreach (var item in res)
            {
                PostListItem post = LoadControl("~/User Control/PostListItem.ascx") as PostListItem;
                post.Title = item["title"];
                post.PostID = Convert.ToInt32(item["id"]);
                post.Body = item["date"];
                if (postId != null && postId == post.PostID)
                    post.SetActive();
                post.PostClick += delegate {
                    Response.Redirect(Request.Url.AbsolutePath + "?postid=" + item["id"] + "&posttype=" + ddlCatagory.SelectedValue, true);
                };
                PostList.Controls.Add(post);
            }

        }

        private void LoadPost(int? id)
        {
            if (id == null)
                Server.Transfer("~/Error.html", true);

            MySQLDatabase db = new MySQLDatabase();
            Dictionary<string, object> dict = new Dictionary<string, object>(1);
            dict.Add("@pid", id);
            List<Dictionary<string, string>> res = db.Query("getPostById", dict, true);
            if (res.Count > 0)
            {
				ddlCatagory.SelectedValue = res[0]["type"];
                postTitle.Text = res[0]["title"];
				postSummary.Text = res[0]["summary"];
                postBody.Text = res[0]["body"];
                Title = res[0]["title"];
            }
            else {
                Server.Transfer(Statics.Error);
            }
        }


        protected void ddlCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsolutePath + "?posttype=" + ddlCatagory.SelectedValue);
        }
        public void UpdatePost(int id,string title, string body)
        {
            new MySQLDatabase().Execute("updatePost", new Dictionary<string, object>() {
                {"@pid", id },
				{"@ptype",ddlCatagory.SelectedValue },
                {"@ptitle", title },
				{"@psummary",postSummary.Text },
                {"@pbody",body }
            }, true);

            Response.Redirect(Request.Url.ToString(), true);
        }
		
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["postid"] != null)
                UpdatePost(Convert.ToInt32(Request.QueryString["postid"]), postTitle.Text, postBody.Text);
            else {
				new MySQLDatabase().Execute("addPost", new Dictionary<string, object>() {
					{"@ptype",ddlCatagory.SelectedValue },
					{"@ptitle",postTitle.Text },
					{"@psummary",postSummary.Text },
					{"@pbody",postBody.Text }
				},true);
				Response.Redirect(Request.Url.ToString(), true);
			}
        }

		protected void btnAdd_Click(object sender, EventArgs e) {
			Response.Redirect("~/Admin/EditPost");
		}
	}
}