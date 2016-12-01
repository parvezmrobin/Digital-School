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
		private YearClassSectionTable yearClassSectionTable;

		public TeacherSubjectTable(MySQLDatabase database) {
			db = database;
			yearClassSectionTable = new YearClassSectionTable(db);
		}
		/// <summary>
		/// Returns the year where given teacher takes or took class
		/// </summary>
		/// <param name="teacherUserId"></param>
		/// <returns></returns>
		public List<TextValuePair> GetYear(object teacherUserId) {
			return db.Query("getYearByTUId", new Dictionary<string, object>() { { "@TUId", teacherUserId } }, true).
				Select(x => new TextValuePair { Text = x["year"], Value = x["yearid"] }).ToList();
		}
		/// <summary>
		/// Returns the classes where given teacher takes class in given year
		/// </summary>
		/// <param name="teacherUserId"></param>
		/// <param name="yearId"></param>
		/// <returns></returns>
		public List<TextValuePair> GetClass(object teacherUserId, object yearId) {
			return db.Query("getClassByTUIdYId",
				new Dictionary<string, object>() {
					{"@TUId", teacherUserId },
					{"@YId",  yearId }
				}, true).Select(x => new TextValuePair {
					Text = x["class"],
					Value = x["classid"]
				}).ToList();
		}

		/// <summary>
		/// Returns the sections where given teacher takes class in given year and class
		/// </summary>
		/// <param name="teacherUserId"></param>
		/// <param name="yearId"></param>
		/// <param name="classId"></param>
		/// <returns></returns>
		public List<TextValuePair> GetSection(object teacherUserId, object yearId, object classId) {
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

		/// <summary>
		/// Returns List of SubjectName and TeacherSubjectId
		/// </summary>
		/// <param name="teacherUserName"></param>
		/// <param name="yearClassSectionId"></param>
		/// <returns></returns>
		public List<TextValuePair> GetTeacherSubject(object teacherUserName, object yearClassSectionId) {
			return db.Query("getSubjectByTUNYCSId",
				new Dictionary<string, object>() {
					{"@TUN", teacherUserName },
					{"@YCSId", yearClassSectionId }
				}, true).Select(x => new TextValuePair {
					Text = x["subject"],
					Value = x["id"]
				}).ToList();
		}

		/// <summary>
		/// Returns List of Student having a subject with given teacher in given yearClassSection
		/// </summary>
		/// <param name="teacherUserName">Username of teacher</param>
		/// <param name="yearClassSectionId">Id of corresponding YearClassSection entry</param>
		/// <returns>List of Student</returns>
		public List<Student> GetStudent(object teacherUserName, object yearClassSectionId) {
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

		
		/// <summary>
		/// Returns List of Student having given teacherSubject
		/// </summary>
		/// <param name="teacherSubjectId">Id of corresponding teacherSubject entry</param>
		/// <returns>List of Student having given teacherSubject</returns>
		public List<Student> GetStudent(object teacherSubjectId) {
			return db.Query("GetStudentByTSId", new Dictionary<string, object>() { { "@TSId", teacherSubjectId } }, true).
				Select(x => new Student {
					ID = x["studentid"],
					FirstName = x["firstname"],
					LastName = x["lastname"],
					UserId = x["userid"],
					Roll = Convert.ToInt32(x["roll"]),
					RollYearClassSectionId = x["studentyearclasssectionrollid"]
				}).ToList();
		}
		/// <summary>
		/// Add a new teacherSubject entry
		/// </summary>
		/// <param name="teacherId">Id of correspondint teacher</param>
		/// <param name="subjectId">Id of correspondint subject</param>
		/// <param name="yearClassSectionId">Id of correspondint yearClassSection entry</param>
		/// <returns>Id of newly added teacherSubject entry</returns>
		public int AddTeacherSubject(object teacherId, object subjectId, object yearClassSectionId) {
			return Convert.ToInt32(db.QueryValue("addTeacherSubject", new Dictionary<string, object>() {
				{"TId", teacherId },
				{"@SId", subjectId }	,
				{"@YCSId", yearClassSectionId }
			}, true));
		}

		/// <summary>
		/// Add a new teacherSubject entry
		/// </summary>
		/// <param name="teacherId">Id of correspondint teacher</param>
		/// <param name="subjectId">Id of correspondint subject</param>
		/// <param name="yearId">Id of corresponding year entry</param>
		/// <param name="classId">Id of corresponding class entry</param>
		/// <param name="sectionId">Id of corresponding section entry</param>
		/// <returns>Id of newly added teacherSubject entry</returns>
		public int AddTeacherSubject(object teacherId, object subjectId, object yearId, object classId, object sectionId) {
			return AddTeacherSubject(teacherId, subjectId, yearClassSectionTable.GetYearClassSectionId(yearId, classId, sectionId));
		}

		/// <summary>
		/// Returns list of teacherSubject in given yearClassSection
		/// </summary>
		/// <param name="yearClassSectionId">Id of corresponding yearClassSectionEntry</param>
		/// <returns>List of teacherSubject in given yearClassSection</returns>
		public List<TeacherSubject> GetTeacherSubject(object yearClassSectionId) {
			return db.Query("getSubjectByYCSId", new Dictionary<string, object>() {
				{"@YCSId", yearClassSectionId }
			}, true).Select(x => new TeacherSubject {
				Teacher = new Teacher {
					FirstName = x["firstname"],
					LastName = x["lastname"],
				},
				Name = x["subject"],
				SubjectCode = x["subjectcode"],
				TeacherSubjectId = x["teachersubjectid"],
				TotalMark = Convert.ToInt32(x["totalmark"])
			}).ToList();
		}

		/// <summary>
		/// Removes teacherSubject from given yearClassSection
		/// </summary>
		/// <param name="teahcerId">Id of corresponding teacher</param>
		/// <param name="subjectId">Id of corresponding subject</param>
		/// <param name="yearClassSectionId">Id of corresponding yearClassSection entry</param>
		/// <returns>Number of entries removed</returns>
		public int RemoveTeacherSubject(object teahcerId, object subjectId, object yearClassSectionId) {
			return db.Execute("removeTeacherSubject", new Dictionary<string, object>() { { "@TId", teahcerId }, { "@SId", subjectId }, { "@YCSId", yearClassSectionId } }, true);
		}
		
		/// <summary>
		/// Removes teacherSubject from given yearClassSection
		/// </summary>
		/// <param name="teahcerId">Id of corresponding teacher</param>
		/// <param name="subjectId">Id of corresponding subject</param>
		/// <param name="yearId">Id of corresponding year entry</param>
		/// <param name="classId">Id of corresponding class entry</param>
		/// <param name="sectionId">Id of corresponding section entry</param>
		/// <returns>Number of entries removed</returns>
		public int RemoveTeacherSubject(object teahcerId, object subjectId, object yearId, object classId, object sectionId) {
			return RemoveTeacherSubject(teahcerId, subjectId, yearClassSectionTable.GetYearClassSectionId(yearId, classId, sectionId));
		}
		
		public int RemoveTeacherSubject(object TSId)
        {
            return db.Execute("removeTeacherSubjectByTSId", new Dictionary<string, object>()
            {
                {"@TSId",TSId }
            },true);
        }
	}
}
