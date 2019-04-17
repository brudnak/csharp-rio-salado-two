using System.Web.Mvc;
using A1Construction.Models;
// Andrew Brudnak
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
            if (ModelState.IsValid) return RedirectToAction("ThankYou", model);

            return View(model);
        }

        public ActionResult ThankYou(CustomerModels model)
        {
            return View(model);
        }
    }
}