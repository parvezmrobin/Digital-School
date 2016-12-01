using AspNet.Identity.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace Digital_School.Student
{
	public partial class AskQuestion : Page
	{
		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				MySQLDatabase db = new MySQLDatabase();
				var res = new TeacherTable(db).GetAllTeacher();
				foreach(var item in res) {
					ddlTo.Items.Add(new ListItem(item.FirstName + " " + item.LastName, item.ID.ToString()));
				}
				divSuccess.Visible = false;
			}
		}

		protected void Ask_Click(object sender, EventArgs e) {
			MySQLDatabase db = new MySQLDatabase();

			var userid = User.Identity.GetUserId();
			int studentId = Convert.ToInt32(db.QueryValue(
				"SELECT id FROM student WHERE userid = '" + userid + "' LIMIT 1", null));
			db.Execute("addQuestion",
				new Dictionary<string, object>() {
					{"@askedby", ddlTo.SelectedValue},
					{"@askedto", studentId },
					{"@title", txtSubject.Text },
					{"@body", txtQuestion.Text }
				},
				true);
			divSuccess.Visible = true;
			spanQuestion.InnerText = txtSubject.Text;
			spanTo.InnerText = ddlTo.SelectedItem.Text;
		}
	}
}