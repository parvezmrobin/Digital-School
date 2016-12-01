using AspNet.Identity.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Digital_School.Admin
{
    /// <summary>
    /// Summary description for EditPost1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class EditPost1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string UpdatePost(int id, string title, string body)
        {
            new MySQLDatabase().Execute("updatePost", new Dictionary<string, object>() {
                {"@pid", id },
                {"@ptitle", title },
                {"@pbody",body }
            }, true);

            return null;
        }
    }
}
