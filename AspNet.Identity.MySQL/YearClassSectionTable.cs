using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.MySQL
{
	public class YearClassSectionTable
	{
		private MySQLDatabase db;

		public YearClassSectionTable(MySQLDatabase database) {
			db = database;
		}

		public bool HasYearClassSection(int yearId, int classId, int sectionId) {
			return Convert.ToInt32(db.QueryValue("countYearClassSection", new Dictionary<string, object>() {
						{"@YId", yearId },
						{"@CId", classId },
						{"@SId", sectionId }
					}, true)) > 0;
		}

		public bool HasYearClassSection(string yearId, string classId, string sectionId) {
			return HasYearClassSection(
				Convert.ToInt32(yearId),
				Convert.ToInt32(classId),
				Convert.ToInt32(sectionId)
				);
		}

		public int AddYearClassSection(int yearId, int classId, int sectionId) {
			return Convert.ToInt32(db.QueryValue("addYearClassSection",
				new Dictionary<string, object>() {
					{"@YId", yearId },
					{"@CId", classId },
					{"@SId", sectionId }
				}, true));
		}

		public int AddYearClassSection(string yearId, string classId, string sectionId) {
			return AddYearClassSection(
				Convert.ToInt32(yearId),
				Convert.ToInt32(classId),
				Convert.ToInt32(sectionId)
				);
		}

		public int GetYearClassSectionId(int yearId, int ClassId, int SectionId) {
			return Convert.ToInt32(db.QueryValue("getYearClassSectionId", new Dictionary<string, object>() {
				{"@pclassid", ClassId },
				{"@psectionid", SectionId },
				{"@pyearid", yearId }
			}, true));
		}

		public int GetYearClassSectionId(int yearId, string classId, string sectionId) {
			return GetYearClassSectionId(
				yearId,
				Convert.ToInt32(classId),
				Convert.ToInt32(sectionId)
				);
		}

		public int GetYearClassSectionId(string yearId, string classId, string sectionId) {
			return GetYearClassSectionId(
				Convert.ToInt32(yearId),
				Convert.ToInt32(classId),
				Convert.ToInt32(sectionId)
				);
		}

		public List<TextValuePair> GetClassByYear(int yearId) {
			return db.Query("getClassByYId", new Dictionary<string, object>() { { "@yid", yearId } }, true).
				Select(x => new TextValuePair { Text = x["class"], Value = x["classid"] }).ToList();
		}

		public List<TextValuePair> GetClassByYear(string yearId) {
			return GetClassByYear(Convert.ToInt32(yearId));
		}

		public List<TextValuePair> GetSectionByYearClass(int yearId, int classId) {
			return db.Query("getSectionByYIdCId",
				new Dictionary<string, object>() {
					{"@YId", yearId },
					{"@CId", classId }
				}, true).Select(x => new TextValuePair {
					Text = x["section"],
					Value = x["sectionid"]
				}).ToList();
		}

		public List<TextValuePair> GetSectionByYearClass(string yearId, string classId) {
			return GetSectionByYearClass(Convert.ToInt32(yearId), Convert.ToInt32(classId));
		}
	}
}
