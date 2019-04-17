using System;
using System.Data.SQLite;
using SqlitePractice.Models;

namespace SqlitePractice
{
	internal class Program
	{
		private const string _ConnectionString = @"Data Source=chinook.db;datetimeformat=CurrentCulture;";

		private static void Main(string[] args)
		{
			var newcustomer = GetInput();

			using (var connection = new SQLiteConnection(_ConnectionString))
			{
				connection.Open();
				InsertCustomerData(connection, newcustomer);
				OutputCustomerData(connection);
				// OutputInvoiceData(connection);
			}

			// Reminder for self:
			// If wanting to start with fresh database and just test features without
			// Saving data right click chinook.db in solution explorer and select properties
			// for the option "copy to output directory" switch from copy if newer to copy always
			// Copy if newer will save to db
			// Copy always will start fresh db each program execution

			Console.ReadLine();
		}

		private static void InsertCustomerData(SQLiteConnection connection, Customer customer)
		{
			var command = connection.CreateCommand();
			command.CommandText =
				$"INSERT INTO Customers (FirstName, LastName, Country, Email) VALUES ('{customer.FirstName}','{customer.LastName}','{customer.Country}','{customer.Email}')";
			command.ExecuteNonQuery();
		}

		private static void UpdateCustomerData(SQLiteConnection connection, Customer customer)
		{
			var command = connection.CreateCommand();
			command.CommandText =
				$"UPDATE Customers SET FirstName = '{customer.FirstName}', LastName = '{customer.LastName}', Country = '{customer.Country}', Email = '{customer.Email}' WHERE CustomerID = {customer.CustomerID}";
			command.ExecuteNonQuery();
		}


		private static void DeleteCustomerData(SQLiteConnection connection, int customerId)
		{
			var command = connection.CreateCommand();
			command.CommandText = $"DELETE FROM Customers WHERE CustomerID = {customerId}";
			command.ExecuteNonQuery();
		}

		private static void DeleteInvoiceData(SQLiteConnection connection, int invoiceId)
		{
			var command = connection.CreateCommand();
			command.CommandText = $"DELETE FROM Invoices WHERE InvoiceID = {invoiceId}";
			command.ExecuteNonQuery();
		}

		private static void InsertInvoiceData(SQLiteConnection connection, Invoice invoice)
		{
			var command = connection.CreateCommand();
			command.CommandText =
				$"INSERT INTO Invoices (CustomerID, InvoiceDate, Total) VALUES ({invoice.CustomerId},'{invoice.InvoiceDate}',{invoice.Total})";
			command.ExecuteNonQuery();
		}


		private static void UpdateInvoiceData(SQLiteConnection connection, Invoice invoice)
		{
			var command = connection.CreateCommand();
			command.CommandText =
				$"UPDATE Invoices SET CustomerID = {invoice.CustomerId}, InvoiceDate = '{invoice.InvoiceDate}', Total = {invoice.Total} WHERE InvoiceID = {invoice.InvoiceId}";
			command.ExecuteNonQuery();
		}


		private static Customer GetInput()
		{
			var customer = new Customer();
			Console.WriteLine("Enter first name:");
			customer.FirstName = Console.ReadLine();
			Console.WriteLine("Enter last name:");
			customer.LastName = Console.ReadLine();
			Console.WriteLine("Enter email:");
			customer.Email = Console.ReadLine();
			Console.WriteLine("Enter country:");
			customer.Country = Console.ReadLine();
			return customer;
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
						Console.WriteLine(outputFormat, reader.GetInt32(CustomerFields.CustomerId),
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
						Console.WriteLine(outputFormat, reader.GetInt32(InvoiceFields.InvoiceId),
							reader.GetInt32(InvoiceFields.CustomerId), reader.GetDateTime(InvoiceFields.InvoiceDate),
							reader.GetDecimal(InvoiceFields.Total));
				}
			}
		}
	}
}