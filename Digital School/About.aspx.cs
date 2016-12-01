using AspNet.Identity.MySQL;
using Digital_School.User_Control;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
	public partial class About : Page
	{
		protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack)
            {
                try
                {
                    string dirstr = HttpContext.Current.Server.MapPath("~/Json/");
                    string jsonDirstr = string.Format("history.json");
                    string fullDirstr = Path.Combine(dirstr, jsonDirstr);
                    JObject j = JObject.Parse(File.ReadAllText(fullDirstr));
                    using (StreamReader file = File.OpenText(fullDirstr))
                    using (JsonTextReader reader = new JsonTextReader(file))
                    {
                        //JToken jt = JToken.ReadFrom(reader);
                        //jt = JToken.Parse("{}");
                        JObject j2 = (JObject)JToken.ReadFrom(reader);
                        foreach (JProperty property in j2.Properties())
                        {
                            txtHistory.Text = property.Value.ToString();
                        }
                    }
                }
                catch (Exception)
                {
                    string dirstr = HttpContext.Current.Server.MapPath("~/Json/");
                    string jsonDirstr = string.Format("history.json");
                    string fullDirstr = Path.Combine(dirstr, jsonDirstr);
                    string value1 = txtHistory.Text;
                    //string value2 = HttpUtility.HtmlDecode(value1);
                    JObject j = new JObject(new JProperty("1", value1));
                    File.WriteAllText(fullDirstr, j.ToString());
                    using (StreamWriter file = File.CreateText(fullDirstr))
                    using (JsonTextWriter writer = new JsonTextWriter(file))
                    {
                        j.WriteTo(writer);
                    }
                }

            }





            MySQLDatabase db = new MySQLDatabase();
			List<Dictionary<string, string>> res = db.Query("getAllSpeechSummary", null, true);

			foreach(var item in res) {
				Tile tile = LoadControl("~/User Control/Tile.ascx") as Tile;
				tile.PostID = Convert.ToInt32(item["id"]);
				tile.Title = item["title"];
				tile.Detail = item["summary"];
				tile.Type = 3;
				tile.WidthClass = "col-sm-12";

				tile.TitleClick += delegate {
					Response.Redirect("~/Post.aspx?postid=" + tile.PostID + "&posttype=3");
				};

				speeches.Controls.Add(tile);
			}

			if (!IsPostBack) {
				//TODO Load History from Xml
                
			}
		}

	}
}