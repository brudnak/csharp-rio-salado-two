using System.Collections.Generic;
using System.Data.SQLite;
using System.Web.Mvc;
using CompanyUI.Infrastructure;
using CompanyUI.Models;

namespace CompanyUI.Controllers
{
	public class CustomerController : Controller
	{
		private const string _ConnectionString =
			@"Data Source=|DataDirectory|chinook.db;datetimeformat=CurrentCulture;";

		// Andrew Brudnak
		// AND2180221
		// CIS262AD - C# Level II - Class # 31838

		public ActionResult Index()
		{
			var output = new List<CustomerModels>();
			using (var connection = new SQLiteConnection(_ConnectionString))
			{
				connection.Open();
				using (var command = connection.CreateCommand())
				{
					command.CommandText = "SELECT customerid, firstname, lastname, country, email FROM customers";
					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							var customer = new CustomerModels
							{
								CustomerId = reader.GetInt32(CustomerFields.CustomerId),
								FirstName = reader.GetString(CustomerFields.FirstName),
								LastName = reader.GetString(CustomerFields.LastName),
								CustomerCountry = reader.GetString(CustomerFields.Country),
								CustomerEmail = reader.GetString(CustomerFields.Email)
							};

							output.Add(customer);
						}
					}
				}
			}

			return View(output);
		}

		public ActionResult Edit(int id)
		{
			CustomerModels customer = null;
			using (var connection = new SQLiteConnection(_ConnectionString))
			{
				connection.Open();
				using (var command = connection.CreateCommand())
				{
					command.CommandText =
						$"SELECT customerid, firstname, lastname, country, email FROM customers WHERE CustomerID = {id}";

					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
							customer = new CustomerModels
							{
								CustomerId = reader.GetInt32(CustomerFields.CustomerId),
								FirstName = reader.GetString(CustomerFields.FirstName),
								LastName = reader.GetString(CustomerFields.LastName),
								CustomerCountry = reader.GetString(CustomerFields.Country),
								CustomerEmail = reader.GetString(CustomerFields.Email)
							};
					}
				}
			}

			return View(customer);
		}

		[HttpPost]
		public ActionResult Edit(CustomerModels customer)
		{
			if (!ModelState.IsValid) return View(customer);
			using (var connection = new SQLiteConnection(_ConnectionString))
			{
				connection.Open();
				using (var command = connection.CreateCommand())
				{
					command.CommandText =
						$"UPDATE Customers SET FirstName = '{customer.FirstName}', LastName = '{customer.LastName}', Country = '{customer.CustomerCountry}', Email = '{customer.CustomerEmail}' WHERE CustomerID = {customer.CustomerId}";
					command.ExecuteNonQuery();
				}
			}

			return RedirectToAction("Index");
		}


		public ActionResult Details(int id)
		{
			CustomerModels customer = null;
			using (var connection = new SQLiteConnection(_ConnectionString))
			{
				connection.Open();
				using (var command = connection.CreateCommand())
				{
					command.CommandText =
						$"SELECT customerid, firstname, lastname, country, email FROM customers WHERE CustomerID = {id}";

					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
							customer = new CustomerModels
							{
								CustomerId = reader.GetInt32(CustomerFields.CustomerId),
								FirstName = reader.GetString(CustomerFields.FirstName),
								LastName = reader.GetString(CustomerFields.LastName),
								CustomerCountry = reader.GetString(CustomerFields.Country),
								CustomerEmail = reader.GetString(CustomerFields.Email)
							};
					}
				}
			}

			return View(customer);
		}

		public ActionResult Delete(int id)
		{
			using (var connection = new SQLiteConnection(_ConnectionString))
			{
				connection.Open();
				using (var command = connection.CreateCommand())
				{
					command.CommandText = $"DELETE FROM Customers WHERE CustomerID = {id}";
					command.ExecuteNonQuery();
				}
			}

			return RedirectToAction("Index");
		}

		public ActionResult Create()
		{
			var customer = new CustomerModels();
			return View(customer);
		}

		[HttpPost]
		public ActionResult Create(CustomerModels customer)
		{
			if (!ModelState.IsValid) return View(customer);
			using (var connection = new SQLiteConnection(_ConnectionString))
			{
				connection.Open();
				using (var command = connection.CreateCommand())
				{
					command.CommandText =
						$"INSERT INTO Customers (FirstName, LastName, Country, Email) VALUES ('{customer.FirstName}','{customer.LastName}','{customer.CustomerCountry}','{customer.CustomerEmail}')";
					command.ExecuteNonQuery();
				}
			}

			return RedirectToAction("Index");
		}
	}
}