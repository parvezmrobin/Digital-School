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
		void Application_Start(object sender, EventArgs e) {
			// Code that runs on application startup
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			createDemoRoleAndAccount();
		}

		private void createDemoRoleAndAccount() {
			ApplicationDbContext context = new ApplicationDbContext();
			var roleStore = new RoleStore<IdentityRole>(context);
			var roleManager = new RoleManager<IdentityRole>(roleStore);
			IdentityResult resRole, resUser;
			if (!roleManager.RoleExists(RoleTable.Student)) {
				resRole = roleManager.Create(new IdentityRole(RoleTable.Student));
				if (!resRole.Succeeded)
					throw new InvalidOperationException(resRole.Errors.FirstOrDefault());
			}

			if (!roleManager.RoleExists(RoleTable.Teacher)) {
				resRole = roleManager.Create(new IdentityRole(RoleTable.Teacher));
				if (!resRole.Succeeded)
					throw new InvalidOperationException(resRole.Errors.FirstOrDefault());
			}

			if (!roleManager.RoleExists(RoleTable.Admin)) {
				resRole = roleManager.Create(new IdentityRole(RoleTable.Admin));
				if (!resRole.Succeeded)
					throw new InvalidOperationException(resRole.Errors.FirstOrDefault());
			}

			var userStore = new UserStore<ApplicationUser>(context);
			var userManager = new UserManager<ApplicationUser>(userStore);
			userManager.PasswordValidator = new PasswordValidator() {
				RequireDigit = false,
				RequiredLength = 1,
				RequireLowercase = false,
				RequireNonLetterOrDigit = false,
				RequireUppercase = false
			};
			if((from user in userManager.Users where user.UserName == RoleTable.Student select user).Count() == 0) {
				ApplicationUser user = new ApplicationUser() { UserName = RoleTable.Student, Email = "student@student.com" };
				resUser = userManager.Create(user, RoleTable.Student);
				if (!resUser.Succeeded)
					throw new Exception(resUser.Errors.FirstOrDefault());
				string userId = userManager.FindByName(RoleTable.Student).Id;
				resRole = userManager.AddToRole(userId, RoleTable.Student);
				if (!resRole.Succeeded)
					throw new Exception(resRole.Errors.FirstOrDefault());
			}
			if ((from user in userManager.Users where user.UserName == RoleTable.Teacher select user).Count() == 0) {
				ApplicationUser user = new ApplicationUser() { UserName = RoleTable.Teacher, Email = "teacher@teacher.com" };
				resUser = userManager.Create(user, RoleTable.Teacher);
				if (!resUser.Succeeded)
					throw new Exception(resUser.Errors.FirstOrDefault());
				string userId = userManager.FindByName(RoleTable.Teacher).Id;
				resRole = userManager.AddToRole(userId, RoleTable.Teacher);
				if (!resRole.Succeeded)
					throw new Exception(resRole.Errors.FirstOrDefault());
			}
			if ((from user in userManager.Users where user.UserName == RoleTable.Admin select user).Count() == 0) {
				ApplicationUser user = new ApplicationUser() { UserName = RoleTable.Admin, Email = "admin@admin.com" };
				resUser = userManager.Create(user, RoleTable.Admin);
				if (!resUser.Succeeded)
					throw new Exception(resUser.Errors.FirstOrDefault());
				string userId = userManager.FindByName(RoleTable.Admin).Id;
				resRole = userManager.AddToRole(userId, RoleTable.Admin);
				if (!resRole.Succeeded)
					throw new Exception(resRole.Errors.FirstOrDefault());
			}
		}

		void Application_Error(object sender, EventArgs e) {
			Exception ex = Server.GetLastError();
			MySQLDatabase db = new MySQLDatabase();
			while(ex != null) {
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