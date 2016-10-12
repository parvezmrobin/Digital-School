using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.MySQL
{
	public class TeacherTable
	{
		private MySQLDatabase db;

		public TeacherTable(MySQLDatabase database) {
			db = database;
		}

		public List<Teacher> GetAllTeacher() {
			return db.Query("getAllTeacher", null, true).Select(x => new Teacher {
				FirstName = x["firstname"],
				LastName = x["lastname"],
				ID = Convert.ToInt32(x["id"]),
				Designation = x["designation"],
				Qualification = x["qualification"]
			}).ToList();
		}
	}
}
