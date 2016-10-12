using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.MySQL
{
	public class Student
	{
		public string ID { get; set; }	
		public string UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Roll { get; set; }
		public string FullName { get { return FirstName + " " + LastName; } }
		public override string ToString() {
			return Roll + ". " + FullName;
		}
	}
}
