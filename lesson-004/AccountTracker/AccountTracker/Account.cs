using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountTracker
{
    // Andrew Brudnak
    // Lesson 04
    // CIS262AD - C# Level II - Class # 31838 
    public class Account
    {
            public string AccountName { get; set; }
            public DateTime InvoiceDate { get; set; }
            public DateTime DueDate { get; set; }
            public double AmountDue { get; set; }
    }
}
