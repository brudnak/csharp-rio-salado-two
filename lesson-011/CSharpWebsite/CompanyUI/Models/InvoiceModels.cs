using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CompanyUI.Models
{
	public class InvoiceModels
	{
		[DisplayName("Invoice ID#")] public int InvoiceId { get; set; }


		[DisplayName("Customer ID#")] public int CustomerId { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		[DisplayName("Invoice Date")]
		[Required]
		public DateTime InvoiceDate { get; set; }

		[DataType(DataType.Currency)]
		[RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Total must be a numeric value.")]
		public decimal Total { get; set; }
	}
}