using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Digital_School.Models;

namespace Digital_School.Account
{
	public partial class Login : Page
	{
		protected void Page_Load(object sender, EventArgs e) {
			if (User.Identity.IsAuthenticated)
				Response.Redirect("~");

			ForgotPasswordHyperLink.NavigateUrl = "Forgot";

			if (!string.IsNullOrEmpty(Request.QueryString["ReturnUrl"])) {
				hLogin.Visible = true;
			} else {
				hLogin.Visible = false;
			}
		}

		protected void LogIn(object sender, EventArgs e) {
			if (IsValid) {
				// Validate the user password
				var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
				var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

				var result = signinManager.PasswordSignIn(txtUsername.Text, txtPassword.Text, RememberMe.Checked, shouldLockout: true);

				switch (result) {
				case SignInStatus.Success:
					IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
					break;
				case SignInStatus.LockedOut:
					Response.Redirect("/Account/Lockout");
					break;
				case SignInStatus.RequiresVerification:
					Response.Redirect(string.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
													Request.QueryString["ReturnUrl"],
													RememberMe.Checked),
									  true);
					break;
				case SignInStatus.Failure:
				default:
					FailureText.Text = "Invalid login attempt";
					ErrorMessage.Visible = true;
					break;
				}
			}
		}
	}
}