using AspNet.Identity.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School
{
	public partial class Teachers : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				MySQLDatabase db = new MySQLDatabase();
				gvDetail.DataSource = new TeacherTable(db).GetAllTeacher().Select(x => new {
					Name = x.FullName, Designation = x.Designation, Qualification = x.Qualification
				}).ToList();
				gvDetail.DataBind();
				
			}
		}

		protected void gvName_SelectedIndexChanged(object sender, EventArgs e) {

		}
	}
}