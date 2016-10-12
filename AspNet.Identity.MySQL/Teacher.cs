using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.MySQL
{
	public class Teacher
	{
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Designation { get; set; }
		public string Qualification { get; set; }
		public string FullName { get { return FirstName + " " + LastName; } }
	}
}
