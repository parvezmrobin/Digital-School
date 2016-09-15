using AspNet.Identity.MySQL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School.Admin
{
	public partial class Response : System.Web.UI.Page
	{
		//TODO Impelement Previous, Select, Next buttons
		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				var resId = Request.QueryString["resid"];
				if (resId == null) {
					Server.Transfer(Statics.Error404, false);
				}

				MySQLDatabase db = new MySQLDatabase();
				var res = db.Query("getResponseById", new Dictionary<string, object>() { { "@pid", Convert.ToInt32(resId) } }, true);
				if (res.Count == 0) {
					Server.Transfer(Statics.Error404, false);
				}

				var row = res[0];
				res = db.Query("getApplicationById", new Dictionary<string, object>() { { "@pid", Convert.ToInt32(row["applicationid"]) } }, true);
				if (res.Count == 0) {
					Server.Transfer(Statics.Error404, false);
				}
				spanResId.InnerText = resId;
				lblAppId.Text = row["applicationid"];
				aAppId.HRef = "~/Admin/Application?appid=" + lblAppId.Text;
				lblFirstName.Text = row["firstname"];
				lblLastName.Text = row["lastname"];
				lblFathersName.Text = row["fathersname"];
				lblMothersName.Text = row["mothersname"];
				lblGenderName.Text = (row["gender"] == "1") ? "Female" : (row["gender"] == "2") ? "Male" : "Other";
				lblBirthDate.Text = row["birthdate"];
				lblAddress.Text = row["address"];
				lblEmail.Text = row["email"];
				lblPhoneNo.Text = row["phoneNumber"];

				if (res[0]["type"] == "1") {
					//Student
					sectionStd.Visible = true;
					lblClass.Text = db.QueryValue(
						"getClassById",
						new Dictionary<string, object>() { { "@pid", Convert.ToInt32(row["class"]) } },
						true).ToString();
					lblGaurdianOccupation.Text = row["GaurdianOccupation"];
					lblGaurdianOccupationDetail.Text = row["GaurdianOccupationDetail"];
				} else {
					//Teacher
					sectionTch.Visible = true;
					lblDesignation.Text = db.QueryValue("getDesignationById",
						new Dictionary<string, object>() { { "@Pid", Convert.ToInt32(row["designationId"]) } },
						true).ToString();
					lblQualification.Text = row["qualification"];
				}

				string root = Server.MapPath("~");
				var files = Directory.GetFiles(Server.MapPath("~/Response/" + resId));

				var ext = Path.GetExtension(files[0]);
				if (ext == ".zip" || ext == ".rar") {
					aImage.HRef = files[1];
					imgThumb.Src = "~/" + files[1].Substring(root.Length);
					if (files.Length > 1)
						aAttachment.HRef = files[0];
				} else {
					aImage.HRef = files[0];
					imgThumb.Src = "~/" + files[0].Substring(root.Length);
					if (files.Length > 1)
						aAttachment.HRef = files[1];
				}

			}
		}
	}
}