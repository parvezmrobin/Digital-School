﻿using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Digital_School.Models;

namespace Digital_School.Account
{
    public partial class ForgotPassword : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Forgot(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user's email address
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ApplicationUser user = manager.FindByName(UserName.Text);
                if (user == null)
                {
                    FailureText.Text = "The user either does not exist.";
                    ErrorMessage.Visible = true;
                    return;
                }
				if (user.EmailConfirmed) {
					FailureText.Text = "The email is not confirmed.";
					ErrorMessage.Visible = true;
					return;
				}
				// For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
				// Send email with the code and the redirect to reset password page
				string code = manager.GeneratePasswordResetToken(user.Id);
				string callbackUrl = IdentityHelper.GetResetPasswordRedirectUrl(code, Request);
				manager.SendEmail(user.Id, "Reset Password", 
					"Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>." +
					"<br/> <br/>" +
					"Click the following link if you are facing problem:<br/>" + callbackUrl
					);
				loginForm.Visible = false;
                DisplayEmail.Visible = true;
            }
        }
    }
}