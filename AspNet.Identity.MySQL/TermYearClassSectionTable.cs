using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.MySQL
{
	public class TermYearClassSectionTable
	{
		private MySQLDatabase db;

		public TermYearClassSectionTable(MySQLDatabase database) {
			db = database;
		}

		/// <summary>
		/// Rerturns a List of TextValuePair where Text is term name and Value is termYearClassSectionId
		/// </summary>
		/// <param name="yearClassSectionId"></param>
		/// <returns></returns>
		public List<TextValuePair> GetTermByYearClassSection(int yearClassSectionId) {
			return db.Query("getTermByYCSId", new Dictionary<string, object>() {
				{"@YCSId", yearClassSectionId }
			}, true).Select(x => new TextValuePair {
				Text = x["term"],
				Value = x["id"]
			}).ToList();
		}
		public List<TextValuePair> GetTermByYearClassSection(int yearId, int classId, int sectionId) {
			return GetTermByYearClassSection(new YearClassSectionTable(db).GetYearClassSectionId(yearId, classId, sectionId));
		}

		public List<TextValuePair> GetTermByYearClassSection(int yearId, string classId, string sectionId) {
			return GetTermByYearClassSection(
				yearId,
				Convert.ToInt32(classId),
				Convert.ToInt32(sectionId));
		}

		public List<TextValuePair> GetTermByYearClassSection(string yearId, string classId, string sectionId) {
			return GetTermByYearClassSection(
				Convert.ToInt32(yearId),
				Convert.ToInt32(classId),
				Convert.ToInt32(sectionId));
		}
	}
}
