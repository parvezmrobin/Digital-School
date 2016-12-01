using Digital_School.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Digital_School.Admin
{
    /// <summary>
    /// Summary description for LoadLatLong2
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LoadLatLong2 : System.Web.Services.WebService
    {

        [WebMethod]
        public void jsonWrite(string history, string history2, string history3, string history4)
        {
            string dirstr = HttpContext.Current.Server.MapPath("~/Json/");
            string jsonDirstr = string.Format("latLong.json");
            string fullDirstr = Path.Combine(dirstr, jsonDirstr);
            string value1 = history;
            string value2 = history2;
            //string value2 = HttpUtility.HtmlDecode(value1);
            JObject j = new JObject(new JProperty("1", history + " " + history2 + " " + history3 + " " + history4));
            File.WriteAllText(fullDirstr, j.ToString());
            using (StreamWriter file = File.CreateText(fullDirstr))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                j.WriteTo(writer);
            }
        }

        [WebMethod]
        public MultipleValue jsonRead()
        {
            try
            {
                string dirstr = HttpContext.Current.Server.MapPath("~/Json/");
                string jsonDirstr = string.Format("latLong.json");
                string fullDirstr = Path.Combine(dirstr, jsonDirstr);
                JObject j = JObject.Parse(File.ReadAllText(fullDirstr));
                using (StreamReader file = File.OpenText(fullDirstr))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    //JToken jt = JToken.ReadFrom(reader);
                    //jt = JToken.Parse("{}");
                    JObject j2 = (JObject)JToken.ReadFrom(reader);
                    string value3 = null;
                    foreach (JProperty property in j2.Properties())
                    {
                        value3 = property.Value.ToString();

                        //history = value3;
                    }
                    string[] values = value3.Split(' ');
                    return new MultipleValue
                    {
                        Value = values[0],
                        Value2 = values[1],
                        Value3 = values[2],
                        Value4 = values[3]
                    };
                }
            }
            catch (Exception)
            {
                string dirstr = HttpContext.Current.Server.MapPath("~/Json/");
                string jsonDirstr = string.Format("latLong.json");
                string fullDirstr = Path.Combine(dirstr, jsonDirstr);
                //string value2 = HttpUtility.HtmlDecode(value1);
                JObject j = new JObject(new JProperty("1", "0.0" + " " + "0.0" + " " + "" + " " + ""));
                File.WriteAllText(fullDirstr, j.ToString());
                using (StreamWriter file = File.CreateText(fullDirstr))
                using (JsonTextWriter writer = new JsonTextWriter(file))
                {
                    j.WriteTo(writer);
                }
                JObject j2 = JObject.Parse(File.ReadAllText(fullDirstr));
                using (StreamReader file = File.OpenText(fullDirstr))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    //JToken jt = JToken.ReadFrom(reader);
                    //jt = JToken.Parse("{}");
                    JObject j3 = (JObject)JToken.ReadFrom(reader);
                    string value3 = null;
                    foreach (JProperty property in j2.Properties())
                    {
                        value3 = property.Value.ToString();

                        //history = value3;
                    }
                    string[] values = value3.Split(' ');
                    return new MultipleValue
                    {
                        Value = values[0],
                        Value2 = values[1],
                        Value3 = values[2],
                        Value4 = values[3]
                    };
                }
            }
        }
    }
}
