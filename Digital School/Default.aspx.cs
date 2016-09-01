using AspNet.Identity.MySQL;
using Digital_School.User_Control;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Digital_School
{
	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				#region Create Xml for slide show
				string dirstr = Server.MapPath("~/Slideshow");
				if (Directory.Exists(dirstr)) {
					string rootdir = Server.MapPath("~");
					string[] files = Directory.GetFiles(dirstr);
					XmlDocument xml = new XmlDocument();
					XmlNode rootnode = xml.CreateElement("Advertisements");
					xml.AppendChild(rootnode);

					foreach (string img in files) {
						XmlNode node = xml.CreateElement("Ad");
						XmlNode url = xml.CreateElement("ImageUrl");
						url.InnerText = "~/" + img.Substring(rootdir.Length);
						node.AppendChild(url);
						rootnode.AppendChild(node);
					}

					xml.Save(Server.MapPath("~/Xml/slideshow.xml"));

				} else
					throw new Exception("Directory not exists");
				#endregion

				#region Load News, Notice
				MySQLDatabase db = new MySQLDatabase();
				Dictionary<string, object> dict = new Dictionary<string, object>(1);
				dict.Add("@ptype", 1);
				List<Dictionary<string, string>> res = db.Query("getLastSummaryByType", dict);
				if (res.Count > 0) {
					sectionNews.Detail = res[0]["summary"];
					sectionNews.PostID = Convert.ToInt32(res[0]["id"]);
				} else
					Response.Redirect(Statics.Error);
				dict = new Dictionary<string, object>(1);
				dict.Add("@ptype", 2);
				res = db.Query("getLastSummaryByType", dict);
				if (res.Count > 0) {
					sectionNotice.Detail = res[0]["summary"];
					sectionNotice.PostID = Convert.ToInt32(res[0]["id"]);
				} else
					Response.Redirect(Statics.Error);
				//sectionNews.Detail = Statics.getLastSummaryByType(1);
				//sectionNotice.Detail = Statics.getLastSummaryByType(2);
				#endregion

			}

			sectionNews.TitleClick += SectionClick;
			sectionNotice.TitleClick += SectionClick;
			sectionGallary.TitleClick += delegate { Response.Redirect("~/Album.aspx"); };
			sectionTeacher.TitleClick += delegate { Response.Redirect("~/TeacherList.aspx"); };
		}

		protected void SectionClick(object obj, EventArgs e) {
			Tile section = (Tile)obj;
			//Session["posttype"] = section.Type;
			//Session["postid"] = section.PostID;
			//Session.Remove("post");
			Response.Redirect("~/Post.aspx?postid=" + section.PostID + "&posttype=" + section.Type);
		}
	}
}