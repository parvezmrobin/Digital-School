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
		public SingleValue AddMark(int markPortionId, int studentId, int classId, int sectionId, int termId, int mark, string teacherId) {
			MySQLDatabase db = new MySQLDatabase();
			var YCSId = db.QueryValue("getYearClassSectionId", new Dictionary<string, object>() {
				{"@pyearid", db.QueryValue("getYearId", new Dictionary<string, object>() { {"@pyear", DateTime.Now.Year } }, true) },
				{"@pclassId", classId},
				{"@psectionId", sectionId }
			}, true);

			var SYCSRId = db.QueryValue("getSYCSRIdByYCSIdSId", new Dictionary<string, object>() {
				{"@ycsid", YCSId },
				{"@Sid", studentId }
			}, true);

			return new SingleValue() {
				Value = db.QueryValue("addMark", new Dictionary<string, object>() {
					{"@MPId", markPortionId },
					{"@SYCSRId", SYCSRId },
					{"@termid", termId },
					{"@mark", mark },
					{"@TUId", teacherId }
				}, true).ToString()
			};
		}
	}
}
