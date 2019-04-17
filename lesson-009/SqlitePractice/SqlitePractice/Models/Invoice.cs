using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlitePractice.Models
{
	public class Invoice
	{
		public int InvoiceId { get; set; }
		public int CustomerId { get; set; }
		public DateTime InvoiceDate { get; set; }
		public decimal Total { get; set; }
	}
}
