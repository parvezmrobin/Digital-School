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
		private YearClassSectionTable YCSTable;

		public TermYearClassSectionTable(MySQLDatabase database) {
			db = database;
			YCSTable = new YearClassSectionTable(db);
		}

		/// <summary>
		/// Add a new term to given YearClassSection with given percentage
		/// </summary>
		/// <param name="termId">Id of term to be added</param>
		/// <param name="yearClassSectionId">Id of corresponding yearClassSection entry</param>
		/// <param name="percentage">percentage of mark of given term that will contribute in final result</param>
		/// <returns>Number of entries added</returns>
		public int AddTermYearClassSection(int termId, int yearClassSectionId, int percentage) {
			return Convert.ToInt32(db.QueryValue("addTermYearClassSection",
				 new Dictionary<string, object>() {
					 {"@termId", termId },
					 {"@YCSID", yearClassSectionId },
					 {"@percentage", percentage }
				 }, true));
		}

		/// <summary>
		/// Add a new term to given YearClassSection with given percentage
		/// </summary>
		/// <param name="termId">Id of term to be added</param>
		/// <param name="yearClassSectionId">Id of corresponding yearClassSection entry</param>
		/// <param name="percentage">percentage of mark of given term that will contribute in final result</param>
		/// <returns>Number of entries added</returns>
		public int AddTermYearClassSection(string termId, string yearClassSectionId, string percentage) {
			return AddTermYearClassSection(
				Convert.ToInt32(termId),
				Convert.ToInt32(yearClassSectionId),
				Convert.ToInt32(percentage)
				);
		}

		/// <summary>
		/// Add a new term to given YearClassSection with given percentage
		/// </summary>
		/// <param name="termId">Id of term to be added</param>
		/// <param name="yearId">Id of corresponding year entry</param>
		/// <param name="classId">Id of corresponding class entry</param>
		/// <param name="sectionId">Id of corresponding section entry</param>
		/// <param name="percentage">percentage of mark of given term that will contribute in final result</param>
		/// <returns>Number of entries added</returns>
		public int AddTermYearClassSection(string termId, string yearId, string classId, string sectionId, string percentage) {
			return AddTermYearClassSection(
				Convert.ToInt32(termId),
				YCSTable.GetYearClassSectionId(yearId, classId, sectionId),
				Convert.ToInt32(percentage)
				);
		}

		/// <summary>
		/// Rerturns a List of term name and termYearClassSectionId
		/// </summary>
		/// <param name="yearClassSectionId">Id of corresponding yearClassSection entry</param>
		/// <returns>A List of TextValuePair where Text is term name and Value is termYearClassSectionId</returns>
		public List<TextValuePair> GetTermByYearClassSection(int yearClassSectionId) {
			return db.Query("getTermByYCSId", new Dictionary<string, object>() {
				{"@YCSId", yearClassSectionId }
			}, true).Select(x => new TextValuePair {
				Text = x["term"],
				Value = x["id"]
			}).ToList();
		}

		/// <summary>
		/// Rerturns a List of term name and termYearClassSectionId
		/// </summary>
		/// <param name="yearId">Id of corresponding year entry</param>
		/// <param name="classId">Id of corresponding class entry</param>
		/// <param name="sectionId">Id of corresponding section entry</param>
		/// <returns></returns>
		public List<TextValuePair> GetTermByYearClassSection(int yearId, int classId, int sectionId) {
			return GetTermByYearClassSection(new YearClassSectionTable(db).GetYearClassSectionId(yearId, classId, sectionId));
		}

		/// <summary>
		/// Rerturns a List of term name and termYearClassSectionId
		/// </summary>
		/// <param name="yearId">Id of corresponding year entry</param>
		/// <param name="classId">Id of corresponding class entry</param>
		/// <param name="sectionId">Id of corresponding section entry</param>
		/// <returns>A List of TextValuePair where Text is term name and Value is termYearClassSectionId</returns>
		public List<TextValuePair> GetTermByYearClassSection(int yearId, string classId, string sectionId) {
			return GetTermByYearClassSection(
				yearId,
				Convert.ToInt32(classId),
				Convert.ToInt32(sectionId));
		}

		/// <summary>
		/// Rerturns a List of term name and termYearClassSectionId
		/// </summary>
		/// <param name="yearId">Id of corresponding year entry</param>
		/// <param name="classId">Id of corresponding class entry</param>
		/// <param name="sectionId">Id of corresponding section entry</param>
		/// <returns>A List of TextValuePair where Text is term name and Value is termYearClassSectionId</returns>
		public List<TextValuePair> GetTermByYearClassSection(string yearId, string classId, string sectionId) {
			return GetTermByYearClassSection(
				Convert.ToInt32(yearId),
				Convert.ToInt32(classId),
				Convert.ToInt32(sectionId));
		}

		/// <summary>
		/// Returns a List name of term and corresponding percentage
		/// </summary>
		/// <param name="yearClassSectionId">Id of corresponding yearClassSection entry</param>
		/// <returns>A List of TextValuePairs where Text is the name of term and Value is corresponding percentage</returns>
		public List<TextValuePair> GetTermPercentageByYearClassSection(int yearClassSectionId) {
			return db.Query("getTermByYCSId", new Dictionary<string, object>() {
				{"@YCSId", yearClassSectionId }
			}, true).Select(x => new TextValuePair {
				Text = x["term"],
				Value = x["percentage"]
			}).ToList();
		}

		/// <summary>
		/// Returns a List name of term and corresponding percentage
		/// </summary>
		/// <param name="yearId">Id of corresponding year entry</param>
		/// <param name="classId">Id of corresponding class entry</param>
		/// <param name="sectionId">Id of corresponding section entry</param>
		/// <returns>A List of TextValuePairs where Text is the name of term and Value is corresponding percentage</returns>
		public List<TextValuePair> GetTermPercentageByYearClassSection(int yearId, int classId, int sectionId) {
			return GetTermPercentageByYearClassSection(new YearClassSectionTable(db).GetYearClassSectionId(yearId, classId, sectionId));
		}

		/// <summary>
		/// Returns a List name of term and corresponding percentage
		/// </summary>
		/// <param name="yearId">Id of corresponding year entry</param>
		/// <param name="classId">Id of corresponding class entry</param>
		/// <param name="sectionId">Id of corresponding section entry</param>
		/// <returns>A List of TextValuePairs where Text is the name of term and Value is corresponding percentage</returns>
		public List<TextValuePair> GetTermPercentageByYearClassSection(int yearId, string classId, string sectionId) {
			return GetTermPercentageByYearClassSection(
				yearId,
				Convert.ToInt32(classId),
				Convert.ToInt32(sectionId));
		}

		/// <summary>
		/// Returns a List name of term and corresponding percentage
		/// </summary>
		/// <param name="yearId">Id of corresponding year entry</param>
		/// <param name="classId">Id of corresponding class entry</param>
		/// <param name="sectionId">Id of corresponding section entry</param>
		/// <returns>A List of TextValuePairs where Text is the name of term and Value is corresponding percentage</returns>
		public List<TextValuePair> GetTermPercentageByYearClassSection(string yearId, string classId, string sectionId) {
			return GetTermPercentageByYearClassSection(
				Convert.ToInt32(yearId),
				Convert.ToInt32(classId),
				Convert.ToInt32(sectionId));
		}

		public List<TermYearClassSection> GetTerm(object yearClassSectionId) {
			return db.Query("getTermByYCSId", new Dictionary<string, object>() {
				{"@YCSId", yearClassSectionId }
			}, true).Select(x => new TermYearClassSection {
				ID = x["id"],
				Name = x["term"],
				Percentage = Convert.ToInt32(x["percentage"])
			}).ToList();
		}

		public List<TermYearClassSection> GetTerm(object yearId, object classId, object sectionId) {
			return GetTerm(YCSTable.GetYearClassSectionId(yearId, classId, sectionId));
		}

		/// <summary>
		/// Removes all term exist in given YearClassSection
		/// </summary>
		/// <param name="yearClassSectionId">Id of corresponding yearClassSection entry</param>
		/// <returns>Number of entries deleted</returns>
		public int RemoveTermByYearClassSection(int yearClassSectionId) {
			return db.Execute("removeTermByYCSId", new Dictionary<string, object>() { { "@YCSId", yearClassSectionId } }, true);
		}

		/// <summary>
		/// Removes all term exist in given YearClassSection
		/// </summary>
		/// <param name="yearId">Id of corresponding year entry</param>
		/// <param name="classId">Id of corresponding class entry</param>
		/// <param name="sectionId">Id of corresponding section entry</param>
		/// <returns>Number of entries deleted</returns>
		public int RemoveTermByYearClassSection(int yearId, int classId, int sectionId) {
			return RemoveTermByYearClassSection(YCSTable.GetYearClassSectionId(yearId, classId, sectionId));
		}

		/// <summary>
		/// Removes all term exist in given YearClassSection
		/// </summary>
		/// <param name="yearId">Id of corresponding year entry</param>
		/// <param name="classId">Id of corresponding class entry</param>
		/// <param name="sectionId">Id of corresponding section entry</param>
		/// <returns>Number of entries deleted</returns>
		public int RemoveTermByYearClassSection(string yearId, string classId, string sectionId) {
			return RemoveTermByYearClassSection(YCSTable.GetYearClassSectionId(yearId, classId, sectionId));
		}

		/// <summary>
		/// Removes all term exist in given YearClassSection
		/// </summary>
		/// <param name="yearId">Id of corresponding year entry</param>
		/// <param name="classId">Id of corresponding class entry</param>
		/// <param name="sectionId">Id of corresponding section entry</param>
		/// <returns>Number of entries deleted</returns>
		public int RemoveTermByYearClassSection(int yearId, string classId, string sectionId) {
			return RemoveTermByYearClassSection(YCSTable.GetYearClassSectionId(yearId, classId, sectionId));
		}
		
		public int RemoveTermByTYCSId(int termYearClassSectionId)
        {
            return db.Execute("removeTermByTYCSId", new Dictionary<string, object>()
            {
                {"@TYCSId",termYearClassSectionId }
            }, true);
        }
        public object CheckTermByTermId(object termId)
        {
            return db.QueryValue("countTerms", new Dictionary<string, object>()
            {
                {"@tId",termId }
            },true);
        }


	}
}
