using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.MySQL
{
	public class TeacherSubjectTable
	{
		private MySQLDatabase db;

		public TeacherSubjectTable(MySQLDatabase database) {
			db = database;
		}

		public List<TextValuePair> GetClass(string teacherUserId, int yearId) {
			return db.Query("getClassByTUIdYId",
				new Dictionary<string, object>() {
					{"@TUId", teacherUserId },
					{"@YId",  yearId }
				}, true).Select(x => new TextValuePair {
					Text = x["class"],
					Value = x["classid"]
				}).ToList();
		}

		public List<TextValuePair> GetClass(string teacherUserId, string yearId) {
			return GetClass(teacherUserId, Convert.ToInt32(yearId));
		}

		public List<TextValuePair> GetSection(string teacherUserId, int yearId, int classId) {
			return db.Query("getSectionByTUIdYIdCId",
				new Dictionary<string, object>() {
					{"@TUId", teacherUserId },
					{"@YId", yearId },
					{"@CId", classId }
				}, true).Select(x => new TextValuePair {
					Text = x["section"],
					Value = x["sectionid"]
				}).ToList();
		}

		public List<TextValuePair> GetSection(string teacherUserId, string yearId, string classId) {
			return GetSection(teacherUserId, Convert.ToInt32(yearId), Convert.ToInt32(classId));
		}
		/// <summary>
		/// Returns List of SubjectName and TeacherSubjectId
		/// </summary>
		/// <param name="teacherUserName"></param>
		/// <param name="yearClassSectionId"></param>
		/// <returns></returns>
		public List<TextValuePair> GetTecacherSubject(string teacherUserName, int yearClassSectionId) {
			return db.Query("getSubjectByTUNYCSId",
				new Dictionary<string, object>() {
					{"@TUN", teacherUserName },
					{"@YCSId", yearClassSectionId }
				}, true).Select(x => new TextValuePair {
					Text = x["subject"],
					Value = x["id"]
				}).ToList();
		}
		public List<TextValuePair> GetTecacherSubject(string teacherUserName, int yearId, int classId, int sectionId) {
			return GetTecacherSubject(teacherUserName, new YearClassSectionTable(db).GetYearClassSectionId(yearId, classId, sectionId));
		}
		/// <summary>
		/// Returns List of Student having a subject with given teacher in given yearClassSection
		/// </summary>
		/// <param name="teacherUserName"></param>
		/// <param name="yearClassSectionId"></param>
		/// <returns></returns>
		public List<Student> GetStudent(string teacherUserName, int yearClassSectionId) {
			return db.Query("getStudentByTUNYCSId",
				new Dictionary<string, object>() {
					{"@TUN", teacherUserName },
					{"@YCSId", yearClassSectionId }
				}, true).Select(x => new Student {
					ID = x["studentid"],
					UserId = x["userid"],
					FirstName = x["firstname"],
					LastName = x["lastname"],
					Roll = Convert.ToInt32(x["roll"])
				}).ToList();
		}
		public List<Student> GetStudent(string teacherUserName, int yearId, int classId, int sectionId) {
			return GetStudent(teacherUserName, new YearClassSectionTable(db).GetYearClassSectionId(yearId, classId, sectionId));
		}
		/// <summary>
		/// Returns List of Student having given teacherSubject
		/// </summary>
		/// <param name="teacherSubjectId"></param>
		/// <returns></returns>
		public List<Student> GetStudent(int teacherSubjectId) {
			return db.Query("GetStudentByTSId", new Dictionary<string, object>() { { "@TSId", teacherSubjectId } }, true).
				Select(x => new Student {
					ID = x["studentid"],
					FirstName = x["firstname"],
					LastName = x["lastname"],
					UserId = x["userid"],
					Roll = Convert.ToInt32(x["roll"])
				}).ToList();
		}

		public List<Student> GetStudent(string teacherSubjectId) {
			return GetStudent(Convert.ToInt32(teacherSubjectId));
		}
	}
}
