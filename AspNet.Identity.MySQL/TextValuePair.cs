using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.MySQL
{
	public class TextValuePair
	{
		private string text, val;

		public string Text { get { return text; } set { text = value; } }
		public string Value { get { return val; }set { val = value; } }
	}
}
