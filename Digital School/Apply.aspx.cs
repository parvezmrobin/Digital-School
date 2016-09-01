using AspNet.Identity.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School
{
	public partial class Apply : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				divSuccessful.Visible = false;
			}
			if (Session["postid"] == null || Session["type"] == null)
				Response.Redirect("~/404.html", true);

			#region Set Application Title
			MySQLDatabase db = new MySQLDatabase();
			Dictionary<string, object> dict = new Dictionary<string, object>(1);
			dict.Add("pid", Session["postid"]);
			List<Dictionary<string, string>> res = db.Query("getApplicationTitleById", dict);
			if(res.Count != 0) {
				applicationTitle.InnerText = res[0]["title"].ToString();
			} else {
				Response.Redirect("~/Error.html");
			}
			//using (MySqlConnection conn = new MySqlConnection(Statics.ConnectionString)) {
			//	MySqlCommand cmd = new MySqlCommand("getApplicationTitleById", conn);
			//	cmd.CommandType = System.Data.CommandType.StoredProcedure;
			//	cmd.Parameters.AddWithValue("pid", Session["postid"]);
			//	conn.Open();
			//	MySqlDataReader reader = cmd.ExecuteReader();
			//	if (reader.Read()) {
			//		applicationTitle.InnerText = reader[0].ToString();
			//	}
			//}
			#endregion
		}

		protected void btnApply_Click(object sender, EventArgs e) {
			if (IsValid) {
				Dictionary<string, object> dict = new Dictionary<string, object>(6);
				dict.Add("applicationid", Session["postid"]);
				dict.Add("firstname", txtFirstName.Text);
				dict.Add("lastname", txtFirstName.Text);
				dict.Add("email", Email.Text);
				dict.Add("gender", ddlGender.SelectedValue);
				dict.Add("birthdate", txtBirthDate.Text);

				MySQLDatabase db = new MySQLDatabase();
				long? id = Convert.ToInt64(db.QueryValue("addResponse", dict));

				if (id == null)
					Response.Redirect("~/Error", true);
				divSuccessful.Visible = true;
				appId.InnerText = id.ToString();
			}

			//if (IsValid) {
			//	long? id = Statics.insertInto("addResponse",
			//		new MySqlParameter("applicationid", Session["postid"]),
			//		new MySqlParameter("firstname", txtFirstName.Text),
			//		new MySqlParameter("lastname", txtFirstName.Text),
			//		new MySqlParameter("email", Email.Text),
			//		new MySqlParameter("gender", ddlGender.SelectedValue),
			//		new MySqlParameter("birthdate", txtBirthDate.Text)
			//		);

			//	if (id == null)
			//		Response.Redirect("~/Error", true);
			//	divSuccessful.Visible = true;
			//	appId.InnerText = id.ToString();
			//}
		}
	}
}