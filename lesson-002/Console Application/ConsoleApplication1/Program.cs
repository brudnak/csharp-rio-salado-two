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
    class Program
    {
  
        public class PersonalAccount : Account, IPayMyBill
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public override DateTime CalculateDueDate()
            {
                DateTime personalDueDate;
                var today = DateTime.Today;
                personalDueDate = today.AddDays(30);
                return personalDueDate; 
            }
            public void Pay()
            {
                AmountDue = 0;
            }
        }
   
        public class BusinessAccount : Account, IPayMyBill
        {
            public string BusinessName { get; set; }
            public string BusinessAddress { get; set; }
            public override DateTime CalculateDueDate()
            {
                DateTime businessDueDue;
                var today = DateTime.Today;
                businessDueDue = today.AddDays(60);
                return businessDueDue;
            }
            public void Pay()
            {
                AmountDue = 0;
            }
        }

       
        static void Main(string[] args)
        {
            /* Corrected AmountDue to decimal, using "M" suffix to create literal of this type.
             * Without the suffix M, the number is treated as a double and generates a compiler error. 
             * Either "M" or "m" will work according to microsoft documentation. */
            var personalAccount = new PersonalAccount { FirstName = "Andrew", LastName = "Brudnak", AmountDue = 4324.50M };
            var businessAccount = new BusinessAccount { BusinessName = "Rio Salado", BusinessAddress = "2323 W 14th St, Tempe, AZ 85281", AmountDue = 78399.34M };
            OutputAccount(personalAccount);
            OutputAccount(businessAccount);
            
            Console.ReadLine();
            
        }

        static void OutputAccount(Account account)
        {
            var name = string.Empty;
            if (account is PersonalAccount)
            {
                var personalAccount = account as PersonalAccount;
                name = string.Format("{0} {1}", personalAccount.FirstName, personalAccount.LastName, account.CalculateDueDate());
                personalAccount.Pay();
            }
            else
            {
                var businessAccount = account as BusinessAccount;
                name = businessAccount.BusinessName;
                businessAccount.Pay();
            }

            //Console.WriteLine("Name: {0}, Due date: {1:d}, Amount due: {2:C}", name, account.CalculateDueDate(), account.AmountDue);

            Console.WriteLine($"Name: {name}, Due date: {account.CalculateDueDate():d}, Amount due: {account.AmountDue:C}");
        }
    }
}
