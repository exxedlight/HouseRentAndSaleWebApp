using HouseRentAndSaleWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentAndSaleWebApp.Controllers
{
    public class PublicationController : Controller
    {
        // GET: PublicationController
        public ActionResult Index()
        {
            return View(new PublicationViewModel());
        }

        [HttpPost]
        public IActionResult Publish(PublicationViewModel model)
        {

            model.form_message = "Допиши бля!";

            return View("Index", model);
        }
        
    }
}
