using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.MySQL
{
	public class TermTable
	{
		private MySQLDatabase db;

		public TermTable(MySQLDatabase database) {
			db = database;
		}

		public List<TextValuePair> GetAllTerm() {
			return db.Query("getAllTerm", null, true).
				Select(x => new TextValuePair { Text = x["term"], Value = x["termid"] }).ToList();
		}
	}
}
