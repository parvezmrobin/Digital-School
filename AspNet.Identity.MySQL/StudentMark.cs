using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.MySQL
{
	public class StudentMark
	{
		public Student Student { get; set; }
		public string Mark { get; set; }
		public string MarkId { get; set; }
		public string PortionName { get; set; }
		public string Subject { get; set; }
	}
}
