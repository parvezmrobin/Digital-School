using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.MySQL
{
	public class TeacherSubject : Subject
	{
		public Teacher Teacher { get; set; }
		public string TeacherSubjectId { get; set; }
	}
}
