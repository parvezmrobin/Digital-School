using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.MySQL
{
	public class SectionTable
	{
		private MySQLDatabase db;

		public SectionTable(MySQLDatabase database) {
			db = database;
		}

		public List<TextValuePair> GetAllSection() {
			return db.Query("getAllSection", null, true).
				Select(x => new TextValuePair { Text = x["section"], Value = x["sectionid"] }).ToList();
		}
	}
}
