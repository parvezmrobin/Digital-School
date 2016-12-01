using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School.Admin
{
    public partial class EditHistoryContact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                            history.Text = property.Value.ToString();
                        }
                    }
                }
                catch (Exception)
                {
                    string dirstr = HttpContext.Current.Server.MapPath("~/Json/");
                    string jsonDirstr = string.Format("history.json");
                    string fullDirstr = Path.Combine(dirstr, jsonDirstr);
                    string value1 = history.Text;
                    //string value2 = HttpUtility.HtmlDecode(value1);
                    JObject j = new JObject(new JProperty("1", value1));
                    File.WriteAllText(fullDirstr, j.ToString());
                    using (StreamWriter file = File.CreateText(fullDirstr))
                    using (JsonTextWriter writer = new JsonTextWriter(file))
                    {
                        j.WriteTo(writer);
                    }
                }
                try
                {
                    string dirstr = HttpContext.Current.Server.MapPath("~/Json/");
                    string jsonDirstr = string.Format("contact.json");
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
                            txtAddress.Text = property.Value.ToString();
                        }
                    }
                }
                catch (Exception)
                {
                    string dirstr = HttpContext.Current.Server.MapPath("~/Json/");
                    string jsonDirstr = string.Format("contact.json");
                    string fullDirstr = Path.Combine(dirstr, jsonDirstr);
                    string value1 = txtAddress.Text;
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
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            //string value1 = history.Value;
            //string value2 = HttpUtility.HtmlDecode(value1);
            //JObject j = new JObject(new JProperty("1",value2));
            //File.WriteAllText(@"d:\j.json", j.ToString());
            //using (StreamWriter file = File.CreateText(@"d:\j.json"))
            //using (JsonTextWriter writer = new JsonTextWriter(file))
            //{
            //    j.WriteTo(writer);
            //}
        }

        protected void editContact_Click(object sender, EventArgs e)
        {
            string dirstr = HttpContext.Current.Server.MapPath("~/Json/");
            string jsonDirstr = string.Format("contact.json");
            string fullDirstr = Path.Combine(dirstr, jsonDirstr);
            string value1 = txtAddress.Text;
            //string value2 = HttpUtility.HtmlDecode(value1);
            JObject j = new JObject(new JProperty("1", value1));
            File.WriteAllText(fullDirstr, j.ToString());
            using (StreamWriter file = File.CreateText(fullDirstr))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                j.WriteTo(writer);
            }
        }
        protected void editButton_Click(object sender, EventArgs e)
        {
            string dirstr = HttpContext.Current.Server.MapPath("~/Json/");
            string jsonDirstr = string.Format("history.json");
            string fullDirstr = Path.Combine(dirstr, jsonDirstr);
            string value1 = history.Text;
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
}