using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyUI.Models;

namespace CompanyUI.Controllers
{
	public class ReportController : Controller
	{
		
		public ActionResult Index()
		{
			ReportModel model = new ReportModel();
			model.PopulateReport();
			return View(model);
		}
	}
}