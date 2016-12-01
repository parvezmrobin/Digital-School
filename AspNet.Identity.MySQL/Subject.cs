using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.MySQL
{
	public class Subject
	{
		public string ID { get; set; }
		public string SubjectCode { get; set; }
		public string Name { get; set; }
		public int TotalMark { get; set; }

		public override string ToString() {
			return SubjectCode + " - " + Name + " (" + TotalMark + ")";
		}
	}
}
