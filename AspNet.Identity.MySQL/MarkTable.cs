using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.MySQL
{
	public class MarkTable
	{
		private MySQLDatabase db;

		public MarkTable(MySQLDatabase database) {
			db = database;
		}

		public List<StudentMark> GetMark(int teacherSubjectId, int termYearClassSectionId) {
			return db.Query("getMarkByTSIdTYCSId",
				new Dictionary<string, object>() {
					{"@TSId", teacherSubjectId },
					{"@TYCSId", termYearClassSectionId }
				}, true).Select(x => new StudentMark {
					Student = new Student {
						ID = (x["studentid"]),
						FirstName = x["firstname"],
						LastName = x["lastname"],
						Roll = Convert.ToInt32(x["roll"])
					},
					Mark = (x["mark"]),
					MarkId = (x["markid"]),
					PortionName = x["portionname"],
					Subject = x["subject"]
				}).ToList();
		}
		public List<StudentMark> GetMark(string teacherSubjectId, string termYearClassSectionId) {
			return GetMark(Convert.ToInt32(teacherSubjectId), Convert.ToInt32(termYearClassSectionId));
		}
		public List<StudentMark> GetMark(int teacherSubjectId, int termYearClassSectionId, int studentId) {
			return db.Query("getMarkByTSIdSIdTYCSId",
				new Dictionary<string, object>() {
					{"@SId", studentId },
					{"@TSId", teacherSubjectId },
					{"@TYCSId", termYearClassSectionId }
				}, true).Select(x => new StudentMark {
					Student = new Student {
						ID = (x["studentid"]),
						FirstName = x["firstname"],
						LastName = x["lastname"],
						Roll = Convert.ToInt32(x["roll"])
					},
					Mark = (x["mark"]),
					MarkId = (x["markid"]),
					PortionName = x["portionname"],
					Subject = x["subject"]
				}).ToList();
		}

		public List<StudentMark> GetMark(string teacherSubjectId, string termYearClassSectionId, string studentId) {
			return GetMark(Convert.ToInt32(termYearClassSectionId), Convert.ToInt32(termYearClassSectionId), Convert.ToInt32(studentId));
		}

		public List<StudentMark> GetMark(
			string teacherSubejctId = null,
			string yearClassSectionId = null,
			string studentId = null,
			string termYearClassSectionId = null,
			string studentYearClassSectionRollId = null,
			string markPortionId = null) {
			Dictionary<string, object> parameter = new Dictionary<string, object>(6);

			parameter.Add("@TSId", string.IsNullOrEmpty(teacherSubejctId) ? null : teacherSubejctId);
			parameter.Add("@YCSId", string.IsNullOrEmpty(yearClassSectionId) ? null : yearClassSectionId);
			parameter.Add("@SId", string.IsNullOrEmpty(studentId) ? null : studentId);
			parameter.Add("@TYCSId", string.IsNullOrEmpty(termYearClassSectionId) ? null : termYearClassSectionId);
			parameter.Add("@SYCSRId", string.IsNullOrEmpty(studentYearClassSectionRollId) ? null : studentYearClassSectionRollId);
			parameter.Add("@MPId", string.IsNullOrEmpty(markPortionId) ? null : markPortionId);

			return db.Query("getMark", parameter, true).
				Select(x => new StudentMark {
					Student = new Student {
						FirstName = x["firstname"],
						LastName = x["lastname"],
						Roll = Convert.ToInt32(x["roll"]),
						ID = x["studentid"],
						UserId = x["userid"]
					},
					Mark = x["mark"],
					MarkId = x["markid"],
					PortionName = x["portionname"],
					Subject = x["subject"]
				}).ToList();
		}

		public List<StudentMark> GetMark(int? teacherSubejctId, int? yearClassSectionId, int? studentId, int? termYearClassSectionId, int? studentYearClassSectionRollId, int? markPortionId) {
			return GetMark(teacherSubejctId.HasValue ? teacherSubejctId.ToString() : null,
				yearClassSectionId.HasValue ? yearClassSectionId.ToString() : null,
				studentId.HasValue ? studentId.ToString() : null,
				termYearClassSectionId.HasValue ? termYearClassSectionId.ToString() : null,
				studentYearClassSectionRollId.HasValue ? studentYearClassSectionRollId.ToString() : null,
				markPortionId.HasValue ? markPortionId.ToString() : null);

		}
	}
}
