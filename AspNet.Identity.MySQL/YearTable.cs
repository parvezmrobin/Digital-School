using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.MySQL
{
	public class YearTable
	{
		private MySQLDatabase db;

		public YearTable(MySQLDatabase database) {
			db = database;
		}

		public List<TextValuePair> GetAllYear() {
			return db.Query("getAllYear", null, true).
				Select(x => new TextValuePair { Text = x["year"], Value = x["yearid"] }).ToList();
		}

		public int GetYearId(string year) {
			return Convert.ToInt32(db.QueryValue("getYearId", new Dictionary<string, object>() { { "@pyear", year } }, true));
		}

		public int GetYearId(int year) {
			return GetYearId(year.ToString());
		}
	}
}
