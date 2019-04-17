using System;
using System.Data.SQLite;

// Andrew Brudnak
// AND2180221
// 10-13-2018
// CIS262AD - C# Level II - Class # 31838

namespace SqlitePractice
{
	internal class Program
	{
		private const string _ConnectionString = @"Data Source=chinook.db;datetimeformat=CurrentCulture;";

		private static void Main(string[] args)
		{
			using (var connection = new SQLiteConnection(_ConnectionString))
			{
				// add try catch here if time permits
				connection.Open();
				OutputCustomerData(connection);
				OutputInvoiceData(connection);
			}

			Console.ReadLine();
		}

		private static void OutputCustomerData(SQLiteConnection connection)
		{
			using (var command = connection.CreateCommand())
			{
				const string outputFormat = "Customer ID: {0} First Name: {1} Last Name: {2} Country: {3} Email: {4}";
				command.CommandText = "SELECT customerid, firstname, lastname, country, email FROM customers";
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
						Console.WriteLine(outputFormat, reader.GetInt32(CustomerFields.Customerid),
							reader.GetString(CustomerFields.FirstName), reader.GetString(CustomerFields.LastName),
							reader.GetString(CustomerFields.Country),
							reader.GetString(CustomerFields.Email));
				}
			}
		}

		private static void OutputInvoiceData(SQLiteConnection connection)
		{
			using (var command = connection.CreateCommand())
			{
				const string outputFormat = "Invoice ID: {0} Customer ID: {1} Invoice Date: {2:d} Total: {3:C}";
				command.CommandText = "SELECT invoiceid, customerid, invoicedate, total FROM invoices";
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
						Console.WriteLine(outputFormat, reader.GetInt32(InvoiceFields.Invoiceid),
							reader.GetInt32(InvoiceFields.Customerid), reader.GetDateTime(InvoiceFields.InvoiceDate),
							reader.GetDecimal(InvoiceFields.Total));
				}
			}
		}


		public class CustomerFields
		{
			public const int Customerid = 0;
			public const int FirstName = 1;
			public const int LastName = 2;
			public const int Country = 3;
			public const int Email = 4;
		}

		public class InvoiceFields
		{
			public const int Invoiceid = 0;
			public const int Customerid = 1;
			public const int InvoiceDate = 2;
			public const int Total = 3;
		}
	}
}