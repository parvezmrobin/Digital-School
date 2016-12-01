using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.MySQL
{
	public class StudentTable
	{
		private MySQLDatabase db;
		private YearClassSectionTable YCSTable;
		public StudentTable(MySQLDatabase database) {
			db = database;
			YCSTable = new YearClassSectionTable(db);
		}

		public List<Student> GetStudents(object yearId, object classId, object sectionId) {
			var YCSId = YCSTable.GetYearClassSectionId(yearId, classId, sectionId);

			return db.Query("getStudentByYCSId", new Dictionary<string, object>() { { "@YCSId", YCSId } }, true).
				Select(x => new Student {
					FirstName = x["firstname"],
					LastName = x["lastname"],
					Roll = int.Parse(x["roll"]),
					ID = x["studentid"]
				}).ToList();
		}
	}
}
