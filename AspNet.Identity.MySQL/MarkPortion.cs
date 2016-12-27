using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.MySQL.Mark
{
	public class MarkPortion
	{
		public string MarkPortionID { get; set; }
		public string MarkPortionName { get; set; }
		public Subject Subject { get; set; }
		public Teacher Teacher { get; set; }
		public int Percentage { get; set; }
	}

	public class MarkPortionMark : MarkPortion
	{
		public object Mark { get; set; }
	}
}
