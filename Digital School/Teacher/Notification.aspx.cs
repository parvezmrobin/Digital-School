using AspNet.Identity.MySQL;
using Digital_School.User_Control;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School.Teacher
{
	public partial class Notification : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				LoadTeachers();
				divSuccessful.Visible = false;
			}		
		}		

		private void LoadTeachers() {
			ddlTo.DataSource = new MySQLDatabase().Query(
				"getGroupByTUN",
				new Dictionary<string, object>() { { "@TUN", User.Identity.Name } },
				true).Select(x => new {
					Text = x["group"],
					Value = x["id"]
				}).ToList();
			ddlTo.DataBind();
		}

		protected void btnPush_Click(object sender, EventArgs e) {
			if (IsValid) {
				MySQLDatabase db = new MySQLDatabase();
				var TUId = Context.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(User.Identity.Name).Id;
				var res1 = db.Query("GetStudentIdByGId",
					new Dictionary<string, object>() {
					{"@GId", ddlTo.SelectedValue }
					}, true);

				var id = db.QueryValue("addNotification",
					new Dictionary<string, object>() {
					{"@TUId", TUId },
					{"@ptitle", txtSubject.Text },
					{"@pbody", txtDetail.Text }
					}, true);

				foreach (var item in res1) {
					db.Execute("addStudentNotification",
						new Dictionary<string, object>() {
						{ "@SId", item["studentId"] },
						{ "@NId", id }
						}, true);
				}
				notificatinName.InnerText = txtSubject.Text;
				groupName.InnerText = ddlTo.SelectedItem.Text;
				divSuccessful.Visible = true;
			}
		}

		
	}
}