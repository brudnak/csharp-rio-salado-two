using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CompanyUI.Models
{
	public class CustomerModels

	{
		[DisplayName("Customer ID#")] public int CustomerId { get; set; }

		[DisplayName("First name")] [Required] public string FirstName { get; set; }

		[DisplayName("Last name")] [Required] public string LastName { get; set; }

		[DisplayName("Customer Country")]
		[Required]
		public string CustomerCountry { get; set; }

		[DataType(DataType.EmailAddress)]
		[DisplayName("Customer Email")]
		[Required]
		public string CustomerEmail { get; set; }
	}
}