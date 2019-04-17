using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
// Added below using statement to include DisplayName
// This way First name will appear instead of FirstName
using System.ComponentModel;

namespace A1Construction.Models
{
    public class CustomerModels
    {
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [DisplayName("Last name")]
        public string LastName { get; set; }
        [DisplayName("Company name")]
        public string CompanyName { get; set; }
    }
}