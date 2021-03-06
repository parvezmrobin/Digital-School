﻿using System;
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



		public List<StudentMark> GetMark(object teacherSubjectId) {
			return db.Query("getMarkByTSId",
				new Dictionary<string, object>() { { "@TSId", teacherSubjectId } }, true)
					.Select(x => new StudentMark {
						Student = new Student {
							ID = (x["studentid"]),
							FirstName = x["firstname"],
							LastName = x["lastname"],
							Roll = Convert.ToInt32(x["roll"])
						},
						Mark = (x["mark"]),
						MarkId = (x["markid"]),
						PortionId = x["portionId"],
						PortionPercentage = x["portionpercentage"],
						Term = x["term"],
						TermId = x["termid"],
						PortionName = x["portionname"],
						Subject = x["subject"]
					}).ToList();
		}

		public List<StudentMark> GetMark(object teacherSubjectId, object termYearClassSectionId) {
			return db.Query("getMarkByTSIdTYCSId2",
				new Dictionary<string, object>() {
					{"@TSId", teacherSubjectId },
					{"@TYCSId", termYearClassSectionId }
				}, true).Select(x => new StudentMark {
					Student = new Student {
						ID = (x["studentid"]),
						FirstName = x["firstname"],
						LastName = x["lastname"],
						Roll = Convert.ToInt32(x["roll"]),
						RollYearClassSectionId = x["studentyearclasssectionrollid"]
					},
					Mark = (x["mark"]),
					MarkId = (x["markid"]),
					PortionName = x["portionname"],
					PortionId = x["markPortionId"],
					Subject = x["subjectcode"] + " - " + x["subjectname"]
				}).ToList();
		}

		//public List<StudentMark> GetMark(object teacherSubjectId, object termYearClassSectionId, object studentId) {
		//	return db.Query("getMarkByTSIdSIdTYCSId",
		//		new Dictionary<string, object>() {
		//			{"@SId", studentId },
		//			{"@TSId", teacherSubjectId },
		//			{"@TYCSId", termYearClassSectionId }
		//		}, true).Select(x => new StudentMark {
		//			Student = new Student {
		//				ID = (x["studentid"]),
		//				FirstName = x["firstname"],
		//				LastName = x["lastname"],
		//				Roll = Convert.ToInt32(x["roll"])
		//			},
		//			Mark = (x["mark"]),
		//			MarkId = (x["markid"]),
		//			PortionName = x["portionname"],
		//			Subject = x["subject"]
		//		}).ToList();
		//}

		public TextValuePair GetMark(object studentYearClassSectionRollId, object termYearClassSectionId, object markPortionId) {
			return db.Query("getMarkBySYCSRIdTYCSIdMPId",
				new Dictionary<string, object>() {
					{"@SYCSRId", studentYearClassSectionRollId },
					{"@TYCSId", termYearClassSectionId },
					{"@MPId", markPortionId }
				}, true).Select(x => new TextValuePair {
					Text = x["mark"],
					Value = x["markid"]
				}).First();
		}

		public List<StudentMark> Tabulation(object yearId, object classId, object sectionId) {
			var YCSId = new YearClassSectionTable(db).GetYearClassSectionId(yearId, classId, sectionId);

			return db.Query("getMarkByYCSId", new Dictionary<string, object> { { "YCSID", YCSId } }, true).
				Select(x => new StudentMark {
					Student = new Student {
						FirstName = x["firstname"],
						LastName = x["lastname"],
						ID = x["studentid"],
						Roll = int.Parse(x["roll"])
					},
					Mark = x["mark"],
					MarkId = x["markdi"],
					PortionId = x["portionId"],
					PortionName = x["portionname"],
					PortionPercentage = x["portionpercentage"],
					Subject = new Subject {
						Name = x["subject"],
						ID = x["subjectid"],
						SubjectCode = x["subjectcode"],
						TotalMark = int.Parse(x["totalmark"])
					}.ToString(),
					Term = x["term"],
					TermId = x["termid"]
				}).ToList();
		}

		public List<StudentTeacherSubjectMark> GetTermTabulation(object termYearClassSectionId) {
			return db.Query("getMarkByTYCSId2",
				new Dictionary<string, object>() {
					{"@TYCSId", termYearClassSectionId }
				}, true).Select(x => new StudentTeacherSubjectMark {
					Student = new Student {
						ID = (x["studentid"]),
						FirstName = x["firstname"],
						LastName = x["lastname"],
						Roll = Convert.ToInt32(x["roll"]),
						RollYearClassSectionId = x["StudentYearClassSectionRollId"]
					},
					Mark = (x["mark"]),
					MarkId = (x["markid"]),
					PortionName = x["portionname"],
					PortionId = x["markPortionId"],
					PortionPercentage = x["percentage"],
					TermId = termYearClassSectionId.ToString(),
					Subject = new TeacherSubject {
						Name = x["subject"],
						SubjectCode = x["subjectcode"],
						TotalMark = int.Parse(x["totalmark"]),
						TeacherSubjectId = x["teacherSubjectId"],
						ID = x["subjectid"]
					}
				}).ToList();
		}

		public List<Mark.MarkPortionMark> GetStudentMark(object studentYearClassSectionRollId, object termYearClassSectionRollId) {
			return db.Query("getMarkBySYCSRIdTYCSId",
				new Dictionary<string, object>() {
					{"@SYCSRId", studentYearClassSectionRollId },
					{"@TYCSId", termYearClassSectionRollId }
				}, true)
				.Select(x => new Mark.MarkPortionMark {
					Mark = x["mark"],
					MarkPortionID = x["markPortionId"],
					MarkPortionName = x["portionName"],
					Percentage = Convert.ToInt32(x["percentage"]),
					Subject = new Subject {
						Name = x["subject"],
						SubjectCode = x["subjectcode"]
					}
				}).ToList();
		}

		public List<Mark.MarkPortionMark> GetStudentMark(object studentYearClassSectionRollId, object termYearClassSectionRollId, object teacherSubjectId) {
			return db.Query("getMarkBySYCSRIdTYCSIdTSId",
				new Dictionary<string, object>() {
					{"@SYCSRId", studentYearClassSectionRollId },
					{"@TYCSId", termYearClassSectionRollId },
					{"@TSId", teacherSubjectId }
				}, true)
				.Select(x => new Mark.MarkPortionMark {
					Mark = x["mark"],
					MarkPortionID = x["markPortionId"],
					MarkPortionName = x["portionName"],
					Percentage = Convert.ToInt32(x["percentage"]),
					Subject = new Subject {
						Name = x["subject"],
						SubjectCode = x["subjectcode"]
					}
				}).ToList();
		}
		

		public List<StudentMark> GetYearlyMark(object yearClassSectionId) {
			return db.Query("getTotalMarkByYCSId", new Dictionary<string, object>() { { "@YCSId", yearClassSectionId } }, true).
				Select(x => new StudentMark {
					Student = new Student {
						FirstName = x["firstname"],
						LastName = x["lastname"],
						Roll = Convert.ToInt32(x["roll"]),
						ID = x["studentid"]
					},
					Mark = x["mark"]
				}).ToList();
		}
		public List<StudentMark> GetYearlyMark(object yearId, object classId, object sectionId) {
			return GetYearlyMark(new YearClassSectionTable(db).GetYearClassSectionId(yearId, classId, sectionId));
		}
	}
}
