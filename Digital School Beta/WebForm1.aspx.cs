using AspNet.Identity.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Digital_School_Beta {
    public partial class WebForm1 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            MySQLDatabase db = new MySQLDatabase();
            var res = db.Query("SELECT *  FROM student", null);
        }
    }
}