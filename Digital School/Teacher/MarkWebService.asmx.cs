using AspNet.Identity.MySQL;
using Digital_School.Models;
using System;
using System.Collections.Generic;
using System.Web.Services;

namespace Digital_School.Teacher
{
	/// <summary>
	/// Summary description for MarkWebService
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	[System.Web.Script.Services.ScriptService]
	public class MarkWebService : WebService
	{

		[WebMethod]
		public string UpdateMark(int mark, int markId) {
			new MySQLDatabase().Execute("updateMark", new Dictionary<string, object>() {
				{"@pid", markId },
				{"@pmark", mark }
			}, true);

			return null;
		}

		[WebMethod]
		public SingleValue AddMark(int markPortionId, int studentId, int classId, int sectionId, int termYearClassSectionId, int mark, string teacherId) {
			MySQLDatabase db = new MySQLDatabase();
			var YCSId = new YearClassSectionTable(db).GetYearClassSectionId(
				new YearTable(db).GetYearId(DateTime.Now.Year),
				classId,
				sectionId);

			var SYCSRId = new StudentYearClassSectionRollTable(db).GetStudentYearClassSectionRollId(YCSId, studentId);

			return new SingleValue() {
				Value = db.QueryValue("addMark", new Dictionary<string, object>() {
					{"@MPId", markPortionId },
					{"@SYCSRId", SYCSRId },
					{"@TYCSId", termYearClassSectionId },
					{"@mark", mark },
					{"@TUId", teacherId }
				}, true).ToString()
			};
		}
	}
}
