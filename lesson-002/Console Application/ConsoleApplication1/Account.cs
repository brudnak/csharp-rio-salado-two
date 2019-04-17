using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Name: Andrew Brudnak - MEID: AND2180221
// CIS262AD - C# Level II - Class # 31838 
// Lesson 02 
namespace Lesson02
{
    public abstract class Account
    {
        public DateTime InvoiceDate { get; set; }
        public Decimal AmountDue { get; set; }

        public abstract DateTime CalculateDueDate();
    }
}