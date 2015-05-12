using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApplication.Models
{
	public class Word
	{
		public string WordName { get; set; }
		public int Quantity { get; set; }
		public override string ToString()
		{
			return String.Format("{0} - {1}", WordName, Quantity);
		}
	}
}