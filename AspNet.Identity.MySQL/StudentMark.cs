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
		public string PortionId { get; set; }
		public string PortionPercentage { get; set; }
		public string Term { get; set; }
		public string TermId { get; set; }
		public string Subject { get; set; }
	}

	public class StudentSubjectMark : StudentMark
	{
		public new Subject Subject { get; set; }
	}

	public class StudentTeacherSubjectMark : StudentMark
	{
		public new TeacherSubject Subject { get; set; }
	}
}
