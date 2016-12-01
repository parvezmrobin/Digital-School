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

		/// <summary>
		/// Checks if given Year, Class, Section combination exists
		/// </summary>
		/// <param name="yearId">Id of corresponding year entry</param>
		/// <param name="classId">Id of corresponding class entry</param>
		/// <param name="sectionId">Id of corresponding section entry</param>
		/// <returns>True if given Year, Class, Section combination exists, False otherwise</returns>
		public bool HasYearClassSection(object yearId, object classId, object sectionId) {
			return Convert.ToInt32(db.QueryValue("countYearClassSection", new Dictionary<string, object>() {
						{"@YId", yearId },
						{"@CId", classId },
						{"@SId", sectionId }
					}, true)) > 0;
		}
		

		/// <summary>
		/// Add a new Year, Class, Section combination
		/// </summary>
		/// <param name="yearId">Id of corresponding year entry</param>
		/// <param name="classId">Id of corresponding class entry</param>
		/// <param name="sectionId">Id of corresponding section entry</param>
		/// <returns>Number of entries added</returns>
		public int AddYearClassSection(object yearId, object classId, object sectionId) {
			return Convert.ToInt32(db.QueryValue("addYearClassSection",
				new Dictionary<string, object>() {
					{"@YId", yearId },
					{"@CId", classId },
					{"@SId", sectionId }
				}, true));
		}
		

		/// <summary>
		/// Return Id of given Year, Class, Section combination
		/// </summary>
		/// <param name="yearId">Id of corresponding year entry</param>
		/// <param name="classId">Id of corresponding class entry</param>
		/// <param name="sectionId">Id of corresponding section entry</param>
		/// <returns>Id of given Year, Class, Section combination</returns>
		public int GetYearClassSectionId(object yearId, object ClassId, object SectionId) {
			return Convert.ToInt32(db.QueryValue("getYearClassSectionId", new Dictionary<string, object>() {
				{"@pclassid", ClassId },
				{"@psectionid", SectionId },
				{"@pyearid", yearId }
			}, true));
		}
		

		/// <summary>
		/// List of classes exist in given year
		/// </summary>
		/// <param name="yearId">Id of corresponding year entry</param>
		/// <returns>List of TextValuePair where Text is the label of class and Value is the level of class</returns>
		public List<TextValuePair> GetClassByYear(object yearId) {
			return db.Query("getClassByYId", new Dictionary<string, object>() { { "@yid", yearId } }, true).
				Select(x => new TextValuePair { Text = x["class"], Value = x["classid"] }).ToList();
		}

		/// <summary>
		/// List of classes exist in given class in given year
		/// </summary>
		/// <param name="yearId">Id of corresponding year entry</param>
		/// <param name="classId">Id of corresponding class entry</param>
		/// <returns>List of TextValuePair where Text is the label of section and Value is the serial of class</returns>
		public List<TextValuePair> GetSectionByYearClass(object yearId, object classId) {
			return db.Query("getSectionByYIdCId",
				new Dictionary<string, object>() {
					{"@YId", yearId },
					{"@CId", classId }
				}, true).Select(x => new TextValuePair {
					Text = x["section"],
					Value = x["sectionid"]
				}).ToList();
		}

		/// <summary>
		/// Removes given class from given year
		/// </summary>
		/// <param name="yearId">Id of corresponding year entry</param>
		/// <param name="classId">Id of corresponding class entry</param>
		/// <returns>Number of entries removed</returns>
		public int RemoveClassFromYear(object yearId, object classId) {
			return db.Execute("removeYCSByYIdCId", new Dictionary<string, object>() {
				{"@YId", yearId },
				{"@CId", classId }
			}, true);
		}
		
		    public int RemoveSectionFromYCSId(object yearId, object classId, object sectionId)
        {
            return db.Execute("	removeSectionByYCSId", new Dictionary<string, object>() {
                {"@YId", yearId },
                {"@CId", classId },
                {"@SId",sectionId }
            }, true);
        }
		
	}
}
