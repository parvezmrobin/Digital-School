using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.MySQL
{
	public class SubjectYearTable
	{
		private MySQLDatabase db;

		public SubjectYearTable(MySQLDatabase database) {
			db = database;
		}

		public int AddSubjectYear(object subjectId, object yearId, object totalMark) {
			return Convert.ToInt32(db.QueryValue("addSubjectYear", new Dictionary<string, object>() {
				{"@SId", subjectId },
				{"@YId", yearId },
				{"@totalmark", totalMark }
			}, true));
		}

		public bool HasSubject(object subjectId, object yearId) {
			return Convert.ToInt32(db.QueryValue("countSubjectInYear", new Dictionary<string, object>() { { "@SId", subjectId }, { "@YId", yearId } }, true)) > 0;
		}

		public List<Subject> GetSubject(object yearId) {
			return db.Query("getSubjectByYId", new Dictionary<string, object>() { { "@YId", yearId } }, true).
				Select(x => new Subject {
					 Name = x["subject"],
					 SubjectCode = x["subjectcode"],
					 ID = x["subjectid"],
					 TotalMark = Convert.ToInt32(x["totalmark"])
				}).ToList();
		}

		public int RemoveSubject(object subjectId, object yearId) {
			return db.Execute("removeSubjectYear", new Dictionary<string, object>() { { "@SId", subjectId }, { "@YId", yearId } }, true);
		}
	}
}
