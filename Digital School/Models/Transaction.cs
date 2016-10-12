using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Digital_School.Models
{
	public class Transaction
	{
		private DateTime _date;
		public String Date {
			get { return _date.ToString("D"); }
			set { _date = DateTime.Parse(value); }
		}
		[Display(Name = "Transaction Type")]
		public String TransactionType { get; set; }
		public int Amount { get; set; }
		[Display(Name = "Done By")]
		public String DoneBy { get; set; }


	}
}