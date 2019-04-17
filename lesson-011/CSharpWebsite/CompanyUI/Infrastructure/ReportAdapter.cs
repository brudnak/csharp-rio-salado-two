using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace CompanyUI.Infrastructure
{
	public class ReportAdapter
	{
		private const string _ConnectionString =
			@"Data Source=|DataDirectory|chinook.db;datetimeformat=CurrentCulture;";

		public List<Report> GetReportRows()
		{
			// Declare the return type
			List<Report> returnValue = new List<Report>();
			// Create a connection to SQL lite. Wrap in a using statement for safety
			using (SQLiteConnection connection = new SQLiteConnection(_ConnectionString))
			{
				// Create the commamd.. Grrr Twwiiirrrlll
				SQLiteCommand command = connection.CreateCommand();
				// Create the SQL Statement
				string sql = "SELECT Customers.Country, SUM(Invoices.Total) AS 'Total' FROM Invoices INNER JOIN CUSTOMERS ON Invoices.CustomerId = Customers.CustomerId GROUP BY Customers.Country";
				// Pass the CommandText to the command
				command.CommandText = sql;
				// Open the database connection
				connection.Open();
				// Execute a command and return back a reader
				SQLiteDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					// Call a method to retrieve the results
					Report report = GetFromReader(reader);
					// add the instance to the return list
					returnValue.Add(report);
				}
				// return back the results
				return returnValue;

			}
		}

		private Report GetFromReader(DbDataReader reader)
		{
			// Create a new instance of the customer class
			Report report = new Report();
			// Copy the data that retrieved from the database into the class
			report.ReportCountry = reader.GetString(reader.GetOrdinal("Country"));
			report.Total = reader.GetDecimal(reader.GetOrdinal("Total"));
			return report;
		}
	}
}