using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.MySQL
{
	public class MarkPortionTable
	{
		private MySQLDatabase db;
		private YearClassSectionTable YCSTable;

		public MarkPortionTable(MySQLDatabase database) {
			db = database;
			YCSTable = new YearClassSectionTable(db);
		}

		/// <summary>
		/// Returns list of Mark Portion name and corresponding percentage given TeacherSubject Id
		/// </summary>
		/// <param name="teacherSubjectId">Id of corresponding teacherSubject entry</param>
		/// <returns>List of TextValuePair where Text is the Portion Name and Value is corresponding percentage</returns>
		public List<TextValuePair> GetMarkPortionPercentage(object teacherSubjectId) {
			return db.Query("getMarkPortionByTSId", new Dictionary<string, object>() { { "@TSId", teacherSubjectId } }, true).
					Select(x => new TextValuePair { Text = x["portionname"], Value = x["percentage"] }).ToList();
		}

		public List<TextValuePair> GetMarkPortion(object teacherSubjectId) {
			return db.Query("getMarkPortionByTSId", new Dictionary<string, object>() { { "@TSId", teacherSubjectId } }, true).
				Select(x => new TextValuePair { Text = x["portionname"], Value = x["markportionid"] }).ToList();
		}
		
		public int RemoveMarkPortionFromSubject(object markPortionId)
        {
            return db.Execute("removeMarkPortionByMPId", new Dictionary<string, object>()
            {
                {"MPId",markPortionId }
            }, true);
        }
	}
}
