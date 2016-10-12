using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.MySQL
{
	public class ClassTable
	{
		private MySQLDatabase db;

		public ClassTable(MySQLDatabase database) {
			db = database;
		}

		public List<TextValuePair> GetAllClass() {
			return db.Query("getAllClass", null, true).
				Select(x => new TextValuePair { Text = x["class"], Value = x["classid"] }).ToList();
		}
	}
}
