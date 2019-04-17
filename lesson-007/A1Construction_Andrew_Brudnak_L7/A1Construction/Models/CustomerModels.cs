using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
// Andrew Brudnak
namespace A1Construction.Models
{
    public class CustomerModels
    {
        [DisplayName("First name")] [Required] public string FirstName { get; set; }

        [DisplayName("Last name")] [Required] public string LastName { get; set; }

        [DisplayName("Company name")] public string CompanyName { get; set; }

        [DisplayName("Project Cost")]
        // Data type Currency alone will only allow a number to be entered
        // But not if the user has JavaScript disabled in their browser. 
        // Regex added with if on customer controller to handle in case JavaScript is disabled.
        [DataType(DataType.Currency)]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Project cost must be numeric up to two decimal points.")]
        public decimal ProjectCost { get; set; }
    }
}