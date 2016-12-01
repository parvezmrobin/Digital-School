using Digital_School.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Digital_School
{
    /// <summary>
    /// Summary description for LoadContact
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class LoadContact : System.Web.Services.WebService
    {
        //[WebMethod]
        //public void jsonWrite(string history)
        //{
        //    string dirstr = HttpContext.Current.Server.MapPath("~/Json/");
        //    string jsonDirstr = string.Format("contact.json");
        //    string fullDirstr = Path.Combine(dirstr, jsonDirstr);
        //    string value1 = history;
        //    //string value2 = HttpUtility.HtmlDecode(value1);
        //    JObject j = new JObject(new JProperty("1", history));
        //    File.WriteAllText(fullDirstr, j.ToString());
        //    using (StreamWriter file = File.CreateText(fullDirstr))
        //    using (JsonTextWriter writer = new JsonTextWriter(file))
        //    {
        //        j.WriteTo(writer);
        //    }
        //}

        [WebMethod]
        public SingleValue jsonRead()
        {
            try
            {
                //string appDataFolder = HttpContext.Current.Server.MapPath("~/App_Data/");
                //// semi-hardcoded file name for now
                //string jsonFilename = string.Format("PoisonToe_{0}_{1}.json", _unit, _begindate);
                //string fullPath = Path.Combine(appDataFolder, jsonFilename);
                //JObject platypusComplianceJson = JObject.Parse(File.ReadAllText(fullPath));

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
                    string value3 = null;
                    foreach (JProperty property in j2.Properties())
                    {
                        value3 = property.Value.ToString();

                        //history = value3;
                    }
                    return new SingleValue
                    {
                        Value = value3
                    };
                }
            }
            catch (Exception)
            {
                string dirstr = HttpContext.Current.Server.MapPath("~/Json/");
                string jsonDirstr = string.Format("contact.json");
                string fullDirstr = Path.Combine(dirstr, jsonDirstr);
                string value1 = "";
                //string value2 = HttpUtility.HtmlDecode(value1);
                JObject j = new JObject(new JProperty("1", value1));
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
                    return new SingleValue
                    {
                        Value = value3
                    };
                }
            }
        }
    }
}
