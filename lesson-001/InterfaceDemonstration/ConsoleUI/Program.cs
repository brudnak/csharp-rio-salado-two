using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
	class Program
	{
		// Base account is in solution explorer / seperate class file "Account.cs"

		// personal account child class
		public class PersonalAccount : Account
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }
		}

		// business account child class
		public class BusinessAccount : Account
		{
			public string BusinessName { get; set; }
			public string BusinessAddress { get; set; }
		}

		// main method
		static void Main(string[] args)
		{
			DateTime today = DateTime.Today;
			var personalAccount = new PersonalAccount { FirstName = "Andrew", LastName = "Brudnak", InvoiceDate = today, DueDate = today.AddMonths(1) };
			var businessAccount = new BusinessAccount { BusinessName = "Tesla", BusinessAddress = "7014 E Camelback Rd #1210, Scottsdale, AZ 85251", AmountDue = 178399, DueDate = today.AddMonths(3) };
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
				name = string.Format("{0} {1}", personalAccount.FirstName, personalAccount.LastName);
			}
			else
			{
				var businessAccount = account as BusinessAccount;
				name = businessAccount.BusinessName;
			}
			Console.WriteLine("Name: {0}, Due date: {1}, Amount due: {2:C}", name, account.DueDate, account.AmountDue);
		}
	}
}