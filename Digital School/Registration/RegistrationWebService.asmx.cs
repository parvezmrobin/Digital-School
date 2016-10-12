using AspNet.Identity.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Digital_School.Registration
{
	/// <summary>
	/// Summary description for RegistrationWebService
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	[System.Web.Script.Services.ScriptService]
	public class RegistrationWebService : System.Web.Services.WebService
	{

		[WebMethod]
		public Models.SingleValue UsernameExists(string username) {
			Models.SingleValue sv = new Models.SingleValue() {
				Value = (new UserTable<IdentityUser>(new MySQLDatabase()).GetUserByName(username).Count > 0).ToString()
			};

			return sv;
		}
	}
}
