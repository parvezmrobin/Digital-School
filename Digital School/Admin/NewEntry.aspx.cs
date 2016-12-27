using AspNet.Identity.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School.Admin
{
	public partial class NewEntry : System.Web.UI.Page
	{
		private MySQLDatabase db = new MySQLDatabase();
		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				hSuccess.Visible = false;
			}
		}

		protected void Year_ServerValidate(object source, ServerValidateEventArgs args) {
			args.IsValid = Convert.ToInt32(db.QueryValue("countYear", new Dictionary<string, object>() { { "@pyear", txtYear.Text.Trim() } }, true)) == 0;
			if (!args.IsValid)
				hSuccess.Visible = false;
		}
		protected void Class_ServerValidate(object source, ServerValidateEventArgs args) {
            int res = Convert.ToInt32(db.QueryValue("countClass", new Dictionary<string, object>() { { "@CId", txtClassLabel.Text.Trim() } }, true));

            args.IsValid = res == 0;
			if (!args.IsValid)
				hSuccess.Visible = false;
		}
		protected void Section_ServerValidate(object source, ServerValidateEventArgs args) {
			args.IsValid = Convert.ToInt32(db.QueryValue("countSection", new Dictionary<string, object>() { { "@SId", txtSectionLabel.Text.Trim() } }, true)) == 0;
			if (!args.IsValid)
				hSuccess.Visible = false;
		}
		protected void Subject_ServerValidate(object source, ServerValidateEventArgs args) {
			args.IsValid = Convert.ToInt32(db.QueryValue("countSubjectCode", new Dictionary<string, object>() { { "@SC", txtSubjectCode.Text.Trim() } }, true)) == 0;
			if (!args.IsValid)
				hSuccess.Visible = false;
		}
		protected void MarkPortion_ServerValidate(object source, ServerValidateEventArgs args) {
			args.IsValid = Convert.ToInt32(db.QueryValue("countPortion", new Dictionary<string, object>() { { "@PN", txtMarkPortion.Text.Trim() } }, true)) == 0;
			if (!args.IsValid)
				hSuccess.Visible = false;
		}

		protected void btnAddYear_Click(object sender, EventArgs e) {
			if (IsValid) {
				db.Execute("INSERT INTO year VALUES(null, '" + txtYear.Text.Trim() + "');", null);
				hSuccess.InnerText = "Year " + txtYear.Text + " successfully added.";
				hSuccess.Visible = true;
			}
		}

		protected void btnAddClass_Click(object sender, EventArgs e) {
			if (IsValid) {
				db.Execute("INSERT INTO class VALUES(null,'" + txtClassLabel.Text.Trim() + "');", null);
				hSuccess.InnerText = "Class "+ txtClassLabel.Text + " successfully added.";
				hSuccess.Visible = true;
			}
		}

		protected void btnAddSection_Click(object sender, EventArgs e) {
			if (IsValid) {
				db.Execute("INSERT INTO section VALUES(null, '" + txtSectionLabel.Text.Trim()+ "');", null);
				hSuccess.InnerText = "Section "+ txtSectionLabel.Text + " successfully added.";
				hSuccess.Visible = true;
			}
		}

		protected void btnAddSubject_Click(object sender, EventArgs e) {
			if (IsValid) {
				db.Execute("INSERT INTO subject VALUES(null, '" + txtSubjectCode.Text.Trim() + "', '" + txtSubjectName.Text.Trim() + "');", null);
				hSuccess.InnerText = "Subject " + txtSubjectCode.Text + " with name " + txtSubjectName.Text + " successfully added.";
				hSuccess.Visible = true;
			}
		}

		protected void btnAddMarkPortion_Click(object sender, EventArgs e) {
			if (IsValid) {
				db.Execute("INSERT INTO portion VALUES(null, '" + txtMarkPortion.Text.Trim() + "');", null);
				hSuccess.InnerText = "Mark Portion " + txtMarkPortion.Text + " successfully added.";
				hSuccess.Visible = true;
			}
		}

		protected void Term_ServerValidate(object source, ServerValidateEventArgs args) {
			args.IsValid = Convert.ToInt32(db.QueryValue("countTerm", new Dictionary<string, object>() { { "@term", txtTerm.Text.Trim() } }, true)) == 0;
			if (!args.IsValid)
				hSuccess.Visible = false;
		}

		protected void btnAddTerm_Click(object sender, EventArgs e) {
			if (IsValid) {
				db.Execute("INSERT INTO term VALUES(null, '" + txtTerm.Text.Trim() + "');", null);
				hSuccess.InnerText = "Term " + txtTerm.Text.Trim() + " successfully added.";
				hSuccess.Visible = true;
			}
		}
	}
}