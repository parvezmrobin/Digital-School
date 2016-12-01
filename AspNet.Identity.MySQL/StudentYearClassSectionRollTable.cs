using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.MySQL
{
	public class StudentYearClassSectionRollTable
	{
		private MySQLDatabase db = new MySQLDatabase();

		public StudentYearClassSectionRollTable(MySQLDatabase database) {
			db = database;
		}

		public List<Student> GetStudents(object yearClassSectionId) {
			return db.Query("getStudentByYCSId", new Dictionary<string, object>() { { "@YCSId", yearClassSectionId } }, true).
				Select(x => new Student {
					ID=x["studentid"],
					FirstName = x["firstname"],
					LastName = x["lastname"],
					Roll = Convert.ToInt32(x["roll"])
				}).ToList();
		}

		public List<TextValuePair> GetYearByStudentUserId(object studentUserId) {
			return db.Query("getYearBySUId", new Dictionary<string, object>() { { "@SUId", studentUserId } }, true).
				Select(x => new MySQL.TextValuePair { Text = x["year"], Value = x["SYCSRId"] }).ToList();
		}

		public int GetStudentYearClassSectionRollId(object YCSId, object studentId) {
			return Convert.ToInt32(db.QueryValue("getSYCSRIdByYCSIdSId", new Dictionary<string, object>() {
				{"@ycsid", YCSId },
				{"@Sid", studentId }
			}, true));
		}

		public int AddStudentYearClassSectionRoll(object studentId, object yearClassSectionId, object roll) {
			return Convert.ToInt32(db.QueryValue("addStudentYearClassSectionRoll", new Dictionary<string, object>() {
				{"@SId", studentId },
				{"@YCSId", yearClassSectionId },
				{"@roll", roll }
			}, true));
		}
	}
}
