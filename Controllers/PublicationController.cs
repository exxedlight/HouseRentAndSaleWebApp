using HouseRentAndSaleWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HouseRentAndSaleWebApp.Controllers
{
    public class PublicationController : Controller
    {
        // GET: PublicationController
        public ActionResult Index()
        {
            return View(new PublicationViewModel());
        }

        public string validateForm(PublicationViewModel model)
        {
            foreach (IFormFile file in model.images)
            {
                string? ext = Path.GetExtension(file.FileName);
                if (ext != ".jpg" && ext != ".jpeg" && ext != ".png")
                    return "Перевірте коректність форматів зображень!";
            }

            if (model.title.Length < 10) return "Закороткий заголовок оголошення";
            if (model.adres.Length < 5) return "Закоротка адреса";
            if (model.about.Length < 50) return "Закороткий опис";


            double price;
            double square;
            int floor;

            try
            {
                price = double.Parse(model.price);
                if (price < 0) throw new Exception();
            }
            catch
            {
                return "Некоректна ціна";
            }

            try
            {
                square = double.Parse(model.square);
                if (square < 0) throw new Exception();
            }
            catch
            {
                return "Некоректна площа";
            }

            try
            {
                floor = int.Parse(model.floor);
                if (floor < 0) throw new Exception();
            }
            catch
            {
                return "Некоректний поверх";
            }
            return "success";
        }

        [HttpPost]
        public string Publish(PublicationViewModel model)
        {
            //  валідація форми
            string valideteResult = validateForm(model);
            if (valideteResult != "success") return valideteResult;

            //  дані вже валідовано, перетворення їх у числа
            double price = double.Parse(model.price);
            double square = double.Parse(model.square);
            int floor = int.Parse(model.floor);



            return "success";
        }
        
    }
}
