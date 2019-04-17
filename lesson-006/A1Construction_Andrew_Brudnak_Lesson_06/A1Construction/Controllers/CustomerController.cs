using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using A1Construction.Models;


namespace A1Construction.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            var model = new CustomerModels();
            return View(model);
        }
      
        [HttpPost]
        public ActionResult Index(CustomerModels model)
        {
            return RedirectToAction("ThankYou", model);
        }

        public ActionResult ThankYou(CustomerModels model)
        {
            return View(model);
        }
    }
}