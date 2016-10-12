using AspNet.Identity.MySQL;
using Digital_School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace Digital_School.Student
{
	public partial class GraphicalView : System.Web.UI.Page
	{
		//TODO Browse Subjectwise
		private MySQLDatabase db = new MySQLDatabase();

		protected void Page_Init(object sender, EventArgs e) {
			var studentId = new UserTable<ApplicationUser>(db).GetUserId(User.Identity.Name);
			if (!IsPostBack) {
				var res = db.Query("getYearBySUId",
					new Dictionary<string, object>() { { "@SUId", studentId } },
					true);
				ddlYear.Items.Clear();
				foreach (var item in res) {
					ddlYear.Items.Add(new ListItem(item["year"], item["SYCSRId"]));
				}

				res = db.Query("getPortionBySYCSRId",
					new Dictionary<string, object>() { { "@SYCSRId", ddlYear.SelectedValue } },
					true);
				ddlPortion.Items.Clear();
				foreach (var item in res) {
					ddlPortion.Items.Add(new ListItem(item["portionname"], item["portionid"]));
				}
				ddlPortion.Items.Insert(0, new ListItem("All", "all"));
				ReloadChart(null, null);
			}			
		}

		protected void ReloadChart(object sender, EventArgs e) {
			var studentId = new UserTable<ApplicationUser>(db).GetUserId(User.Identity.Name);

			var dataSource = (ddlPortion.SelectedValue == "all") ?
				db.Query("getMarkBySYCSRIdTid",
				new Dictionary<string, object>() {
					{ "@SYCSRId", ddlYear.SelectedValue },
					{ "@TId", ddlTerm.SelectedValue } },
				true) :
				db.Query("getMarkBySYCSRIdTidPId",
				new Dictionary<string, object>() {
					{ "@SYCSRId", ddlYear.SelectedValue },
					{ "@PId", ddlPortion.SelectedValue },
					{ "@TId", ddlTerm.SelectedValue } },
				true);

			Series series;
			foreach (var grp in dataSource.GroupBy(x => x["Portion Name"])) {
				series = new Series(grp.Key);
				
				series.ChartType = SeriesChartType.Spline;
				Chart1.Series.Add(series);
				
				foreach (var item in grp) {
					series.Points.AddXY(item["Subject"], item["Mark"]);
				}
			}

		}
	}
}