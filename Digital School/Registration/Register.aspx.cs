using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Digital_School.Models;
using System.Web.UI.WebControls;
using AspNet.Identity.MySQL;
using System.Collections.Generic;

namespace Digital_School.Account
{
	public partial class Register : Page
	{
		private MySQLDatabase db = new MySQLDatabase();
		protected void Page_Load(object o, EventArgs e) {
			if (!IsPostBack) {
				ddlAs.Items.Add(new ListItem("Student", "student"));
				if (User.IsInRole("Admin")) {
					ddlAs.Items.Add(new ListItem("Teacher", "teacher"));
					ddlAs.Items.Add(new ListItem("Admin", "admin"));
				}
				ddlDesignation.DataSource = db.Query("getAllDesignation", null, true).
					Select(x => new TextValuePair {
						Text = x["designation"],
						Value = x["id"]
					}).ToList();
				ddlDesignation.DataBind();

				ddlClass.DataSource = db.Query("getClassByYId",
					new Dictionary<string, object>() {
						{"@YId", db.QueryValue("getYearId", new Dictionary<string, object>() { {"@pyear", DateTime.Now.Year } }, true) }
					}, true).Select(x => new TextValuePair {
						Text = x["class"],
						Value = x["classid"]
					}).ToList();
				ddlClass.DataBind();
			}
		}
		protected void CreateUser_Click(object sender, EventArgs e) {
			var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
			var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
			var user = new ApplicationUser() {
				UserName = Username.Text,
				Email = Email.Text,
				FirstName = Firstname.Text,
				LastName = Lastname.Text,
				PhoneNumber = PhoneNumber.Text,
				FathersName = FathersName.Text,
				MothersName = MothersName.Text,
				LockoutEnabled = true
			};
			IdentityResult result = manager.Create(user, Password.Text);
			if (result.Succeeded) {
				//For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
				string code = manager.GenerateEmailConfirmationToken(user.Id);
				string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
				manager.SendEmail(user.Id, "Confirm your account",
					"Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>." +
					"<br/> <br/>" +
					"Click the following link if you are facing problem:<br/> " + callbackUrl
					);
				var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new MySQLDatabase()));
				if (ddlAs.Value == "student") {
					result = userManager.AddToRole(user.Id, "Student");
					if (!result.Succeeded) {
						ErrorMessage.Text = result.Errors.FirstOrDefault();
						userManager.Delete(user);
						return;
					}
					var YCSId = db.QueryValue("getYearClassSectionId",
						new Dictionary<string, object>() {
							{"@pyearid", db.QueryValue("getYearId", new Dictionary<string, object>() { {"@pyear", DateTime.Now.Year } }, true)},
							{"@pclassid", ddlClass.SelectedValue },
							{"@psectionid", ddlSection.SelectedValue }
						}, true);
					db.Execute("addStudent", new Dictionary<string, object>() {
						{"@userid", user.Id },
						{"@YearClassSectionId", YCSId },
						{"@GuardianOccupation", txtGaurdianOccupation.Text },
						{"@GuardianOccupationDetail", txtGaurdianOccupationDetail.Text },
						{"@roll", txtRoll.Text }
					}, true);
					
				} else if (ddlAs.Value == "teacher") {
					result = userManager.AddToRole(user.Id, "Teacher");
					if (!result.Succeeded) {
						ErrorMessage.Text = result.Errors.FirstOrDefault();
						userManager.Delete(user);
						return;
					}
					db.Execute("addTeacher", new Dictionary<string, object>() {
						{"@userid", user.Id },
						{"@designationId", ddlDesignation.SelectedValue },
						{"@qualification", txtQualification.Text }
					}, true);
				} else if (ddlAs.Value == "admin") {
					result = userManager.AddToRole(user.Id, "Admin");
					if (!result.Succeeded) {
						ErrorMessage.Text = result.Errors.FirstOrDefault();
						userManager.Delete(user);
						return;
					}
				} else {
					throw new ArgumentException("Provided role does not exists.");
				}

				//signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
				//IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);


			} else {
				ErrorMessage.Text = result.Errors.FirstOrDefault();
			}
		}

		protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e) {
			ddlSection.DataSource = new MySQLDatabase().Query("getSectionByYIdCId",
				new Dictionary<string, object>() {
					{ "@YId", new MySQLDatabase().QueryValue("getYearId",
						new Dictionary<string, object>() { {"@pyear", DateTime.Now.Year } },
						true) },
					{"@CId", ddlClass.SelectedValue }
				}, true).Select(x => new TextValuePair {
					Text = x["section"],
					Value = x["sectionid"]
				}).ToList();
			ddlSection.DataBind();
		}
	}
}