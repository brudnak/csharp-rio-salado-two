using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyUI.Infrastructure;
using CompanyUI.Controllers;
using CompanyUI.Models;

namespace CompanyUI.Models
{
	public class ReportModel
	{
		private ReportAdapter adapter = new ReportAdapter();

		public List<Report> ReportRows
		{
			get;
			set;
		}

		public void PopulateReport()
		{
			ReportRows = adapter.GetReportRows();
		}
	}
}
