using AspNet.Identity.MySQL;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.Owin;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using System.Linq;

namespace Digital_School
{
	public partial class Apply : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				divSuccessful.Visible = false;
			}
			if (Request.QueryString["appid"] == null || Request.QueryString["type"] == null)
				Server.Transfer(Statics.Error404, true);

			#region Initialize Application Area

			MySQLDatabase db = new MySQLDatabase();
			Dictionary<string, object> dict = new Dictionary<string, object>(1);
			dict.Add("@pid", Convert.ToInt32(Request.QueryString["appid"]));
			List<Dictionary<string, string>> res = db.Query("getApplicationById", dict, true);
			if (res.Count > 0) {
				applicationTitle.InnerText = res[0]["title"];
				applicationSummary.InnerText = res[0]["summary"];
				applicationUrl.HRef = res[0]["noticeUrl"];
				setVisibility(Convert.ToInt32(Request.QueryString["type"]), Convert.ToInt32(res[0]["idValue"]));
			} else {
				Server.Transfer("~/Error.html");
			}

			#endregion
		}
		/// <summary>
		/// Sets visibility of fields specified for teacher or student
		/// </summary>
		/// <param name="v">Indecates teacher or student. 1 means student and 2 means teacher</param>
		/// <param name="id">Id value for class(for student) or designation(for teacher)</param>
		private void setVisibility(int v, int id) {
			ViewState["id"] = id;
			Dictionary<string, object> dict = new Dictionary<string, object>(1);
			dict.Add("@pid", id);
			if (v == 1) {
				divStudent.Visible = true;
				txtClass.Text = new MySQLDatabase().QueryValue("getClassById", dict, true).ToString();
				divTeacher.Visible = false;
			} else {
				divTeacher.Visible = true;
				txtDesignation.Text = new MySQLDatabase().QueryValue("getDesignationById", dict, true).ToString();
				divStudent.Visible = false;
			}
		}
		/// <summary>
		/// Click Event Handler for btnApply. Creates a new response.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnApply_Click(object sender, EventArgs e) {
			if (IsValid) {
				Dictionary<string, object> dict = new Dictionary<string, object>(13);
				dict.Add("applicationid", Convert.ToInt32(Request.QueryString["appid"]));
				dict.Add("firstname", txtFirstName.Text);
				dict.Add("lastname", txtFirstName.Text);
				dict.Add("fathersname", txtFathersName.Text);
				dict.Add("mothersname", txtMothersName.Text);
				dict.Add("email", txtEmail.Text);
				dict.Add("gender", ddlGender.SelectedValue);
				dict.Add("birthdate", txtBirthDate.Text);
				dict.Add("phoneNumber", txtBirthDate.Text);
				dict.Add("address", txtAddress.Text);

				if (Convert.ToInt32(Request.QueryString["type"]) == 2) {
					dict.Add("designationId", ViewState["id"]);
					dict.Add("qualification", txtQualification.Text);
					dict.Add("class", null);
					dict.Add("GaurdianOccupation", null);
					dict.Add("GaurdianOccupationDetail", null);
				} else {
					dict.Add("designationId", null);
					dict.Add("qualification", null);
					dict.Add("class", ViewState["id"]);
					dict.Add("GaurdianOccupation", txtGuardianOccupation.Text);
					dict.Add("GaurdianOccupationDetail", txtGuardianOccupationDetail.Text);
				}

				MySQLDatabase db = new MySQLDatabase();
				long? id = Convert.ToInt64(db.QueryValue("addResponse", dict, true));
				if (id == null)
					Server.Transfer(Statics.Error, true);
				divSuccessful.Visible = true;
				appId.InnerText = id.ToString();
				// TODO Send Email with response id

				string dirstr = Server.MapPath(Statics.ResponseFolder + id.ToString());
				if (!Directory.Exists(dirstr)) {
					Directory.CreateDirectory(dirstr);
				}
				if (fuImage.HasFile)
					fuImage.SaveAs(dirstr + "/" + fuImage.FileName);
				if (fuCertificate.HasFile)
					fuCertificate.SaveAs(dirstr + "/" + fuCertificate.FileName);
			}

		}

		protected void imgValidator_ServerValidate(object source, ServerValidateEventArgs args) {
			args.IsValid = true;
			string imgExtension = Path.GetExtension(fuImage.FileName).ToLower();
			if (!(imgExtension == ".jpg" || imgExtension == ".jpeg" || imgExtension == ".png" || imgExtension == ".bmp"))
				args.IsValid = false;
		}

		protected void certValidator_ServerValidate(object source, ServerValidateEventArgs args) {
			args.IsValid = true;
			string certExtension = Path.GetExtension(fuCertificate.FileName).ToLower();
			if (!(certExtension == ".zip" || certExtension == ".rar")) {
				args.IsValid = false;
				certValidator.ErrorMessage = "Upload a file with extension .zip or .rar";
				return;
			}
			if ((fuCertificate.PostedFile.ContentLength / (1024 * 1024)) > 2) {
				args.IsValid = false;
				certValidator.ErrorMessage = "Upload a file of size less than 2 MB";
			}
		}
		
	}
}
