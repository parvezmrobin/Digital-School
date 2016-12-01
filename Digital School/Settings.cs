using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using AspNet.Identity.MySQL;
using Digital_School.User_Control;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Digital_School
{
    public static class Settings
    {
        internal static void WriteXml()
        {
            //string dirstr =Global.root+"/Slideshow";
            //if (Directory.Exists(dirstr))
            //{
                //string rootdir = Global.root;
                //string[] files = Directory.GetFiles(dirstr);
                XmlDocument xml = new XmlDocument();
                XmlNode rootnode = xml.CreateElement("Settings");
                xml.AppendChild(rootnode);

            foreach (KeyValuePair<string, bool> setting in settings)
            {
                XmlElement url = xml.CreateElement("Setting");
                url.InnerText = setting.Value.ToString();
                url.SetAttribute("key", setting.Key);
                rootnode.AppendChild(url);
            }

                //        node.AppendChild(url);
                //    rootnode.AppendChild(node);
                //}

                xml.Save(Global.root+"/Xml/settings.xml");

            //}
            //else
            //    throw new Exception("Directory not exists");
        }
        internal static void ReadXml()
        {
            //XmlReader reader = XmlReader.Create(Global.root + "/Xml/settings.xml");
            //while (reader.Read())
            //{
            //    if (reader.IsStartElement())
            //    {
            //        switch (reader.Name.ToString())
            //        {
            //            case "Setting":

            //                break;
            //        }
            //    }
            //}
            XmlDocument xml = new XmlDocument();
            xml.Load(Global.root + "/Xml/settings.xml");
            foreach(XmlNode node in xml.DocumentElement.ChildNodes)
            {
                settings[node.Attributes["key"].Value] = bool.Parse(node.FirstChild.Value);
            }

        }

        private static Dictionary<string, bool> settings = new Dictionary<string, bool>() {
            {"Notification On Transaction",true},
            {"Notification On Answer", true },
            {"Notification On Question", true },
            {"Notification On Event", true },
            {"Responses Will Be Removed After Creating Result", true }
        };

        public static Dictionary<string, bool> Setting {
            get { return settings; }
        }

        public static string NotificationOnTransaction { get { return "Notification On Transaction"; } }
        public static string NotificationOnAnswer { get { return "Notification On Answer"; } }
        public static string NotificationOnQuestion { get { return "Notification On Question"; } }
        public static string NotificationOnEvent { get { return "Notification On Event"; } }
        public static string ResponsesShouldBeRemoved { get { return "Responses Will Be Removed After Creating Result"; } }

    }
}