using AspNet.Identity.MySQL;
using Digital_School.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Digital_School
{
	public class Global : HttpApplication
	{
		internal static string root = null;
		void Application_Start(object sender, EventArgs e) {
			// Code that runs on application startup
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);


			root = Server.MapPath("~");
			Settings.ReadXml();
		}

		
		void Application_Error(object sender, EventArgs e) {
			Exception ex = Server.GetLastError();
			LogError(ex);

			if(ex is InvalidOperationException && ex.InnerException.Message.Contains("Anti-XSRF")) {
				Response.Redirect("~/ErrorXSRF.html", true);
				Server.ClearError();
			}
		}

		public static void LogError(Exception ex) {
			MySQLDatabase db = new MySQLDatabase();
			while (ex != null) {
				db.Execute("logError",
					new Dictionary<string, object>() {
						{"type", ex.GetType() },
						{"source", ex.Source },
						{"message", ex.Message },
						{"StackTrace", ex.StackTrace }
					},
					true);
				ex = ex.InnerException;
			}
		}
	}
}