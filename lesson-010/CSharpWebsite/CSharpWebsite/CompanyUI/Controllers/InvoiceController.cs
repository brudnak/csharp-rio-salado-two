using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Web.Mvc;
using CompanyUI.Infrastructure;
using CompanyUI.Models;

namespace CompanyUI.Controllers
{
	public class InvoiceController : Controller
	{
		private const string _ConnectionString =
			@"Data Source=|DataDirectory|chinook.db;datetimeformat=CurrentCulture;";

		// Andrew Brudnak
		// AND2180221
		// CIS262AD - C# Level II - Class # 31838

		public ActionResult Index()
		{
			var output = new List<InvoiceModels>();
			using (var connection = new SQLiteConnection(_ConnectionString))
			{
				connection.Open();
				using (var command = connection.CreateCommand())
				{
					command.CommandText = "SELECT invoiceid, customerid, invoicedate, total FROM invoices";
					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							var invoice = new InvoiceModels
							{
								CustomerId = reader.GetInt32(InvoiceFields.CustomerId),
								InvoiceId = reader.GetInt32(InvoiceFields.InvoiceId),
								InvoiceDate = reader.GetDateTime(InvoiceFields.InvoiceDate),
								Total = reader.GetDecimal(InvoiceFields.Total)
							};

							output.Add(invoice);
						}
					}
				}
			}


			return View(output);
		}

		public ActionResult Edit(int id)
		{
			InvoiceModels invoice = null;
			using (var connection = new SQLiteConnection(_ConnectionString))
			{
				connection.Open();
				using (var command = connection.CreateCommand())
				{
					command.CommandText =
						$"SELECT invoiceid, customerid, invoicedate, total FROM invoices WHERE invoiceid = {id}";

					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
							invoice = new InvoiceModels
							{
								CustomerId = reader.GetInt32(InvoiceFields.CustomerId),
								InvoiceId = reader.GetInt32(InvoiceFields.InvoiceId),
								InvoiceDate = reader.GetDateTime(InvoiceFields.InvoiceDate),
								Total = reader.GetDecimal(InvoiceFields.Total)
							};
					}
				}
			}

			return View(invoice);
		}

		[HttpPost]
		public ActionResult Edit(InvoiceModels invoice)
		{
			if (!ModelState.IsValid) return View(invoice);
			using (var connection = new SQLiteConnection(_ConnectionString))
			{
				connection.Open();
				using (var command = connection.CreateCommand())
				{
					command.CommandText =
						$"UPDATE Invoices SET CustomerID = {invoice.CustomerId}, InvoiceDate = '{DateTimeSQLite(invoice.InvoiceDate)}', Total = {invoice.Total} WHERE InvoiceID = {invoice.InvoiceId}";

					var execute = command.ExecuteNonQuery();
				}
			}

			return RedirectToAction("Index");
		}

		private string DateTimeSQLite(DateTime datetime)
		{
			var dateTimeFormat = "{0}-{1}-{2} {3}:{4}:{5}.{6}";
			return string.Format(dateTimeFormat, datetime.Year, datetime.Month, datetime.Day, datetime.Hour,
				datetime.Minute, datetime.Second, datetime.Millisecond);
		}


		public ActionResult Details(int id)
		{
			InvoiceModels invoice = null;
			using (var connection = new SQLiteConnection(_ConnectionString))
			{
				connection.Open();
				using (var command = connection.CreateCommand())
				{
					command.CommandText =
						$"SELECT invoiceid, customerid, invoicedate, total FROM invoices WHERE invoiceid = {id}";

					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
							invoice = new InvoiceModels
							{
								CustomerId = reader.GetInt32(InvoiceFields.CustomerId),
								InvoiceId = reader.GetInt32(InvoiceFields.InvoiceId),
								InvoiceDate = reader.GetDateTime(InvoiceFields.InvoiceDate),
								Total = reader.GetDecimal(InvoiceFields.Total)
							};
					}
				}
			}

			return View(invoice);
		}

		public ActionResult Delete(int id)
		{
			using (var connection = new SQLiteConnection(_ConnectionString))
			{
				connection.Open();
				using (var command = connection.CreateCommand())
				{
					command.CommandText = $"DELETE FROM Invoices WHERE invoiceid = {id}";
					command.ExecuteNonQuery();
				}
			}

			return RedirectToAction("Index");
		}

		public ActionResult Create()
		{
			var invoice = new InvoiceModels();
			return View(invoice);
		}

		[HttpPost]
		public ActionResult Create(InvoiceModels invoice)
		{
			if (!ModelState.IsValid) return View(invoice);
			using (var connection = new SQLiteConnection(_ConnectionString))
			{
				connection.Open();
				using (var command = connection.CreateCommand())
				{
					command.CommandText =
						$"INSERT INTO Invoices (CustomerID, InvoiceDate, Total) VALUES ({invoice.CustomerId},'{invoice.InvoiceDate}',{invoice.Total})";
					command.ExecuteNonQuery();
				}
			}

			return RedirectToAction("Index");
		}
	}
}