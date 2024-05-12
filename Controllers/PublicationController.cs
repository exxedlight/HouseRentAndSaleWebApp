using HouseRentAndSale.DB;
using HouseRentAndSaleWebApp.DB.Entites;
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


            decimal price;
            double square;
            int floor;

            try
            {
                price = decimal.Parse(model.price);
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
            decimal price = decimal.Parse(model.price);
            double square = double.Parse(model.square);
            int floor = int.Parse(model.floor);

            try
            {
                ObjectEntity obj = new ObjectEntity();

                using (Context context = new Context())
                {
                    UserEntity? currentUser = context.Users.FirstOrDefault(x => x.Id.ToString() == Request.Cookies["u"]);
                    obj = new ObjectEntity
                    {
                        about = model.about,
                        adres = model.adres,
                        floor = floor,
                        square = square,
                        price = price,
                        state = model.item_state,
                        title = model.title,
                        userId = currentUser.Id,
                        objtypeId = model.build_type,
                        operation_type = model.operation_type,
                        areaId = model.area,
                        creation_datetime = DateTime.Now
                    };

                    context.Objects.Add(obj);
                    context.SaveChanges();
                }

                string imgDirPath = Path.Combine("wwwroot", "publish_images", obj.Id.ToString());
                Directory.CreateDirectory(imgDirPath);

                for(int i = 0; i < model.images.Count; i++)
                {
                    string ext = Path.GetExtension(model.images[i].FileName);

                    using(var fileStream = new FileStream(Path.Combine(imgDirPath, $"{i}{ext}"), FileMode.Create))
                    {
                        model.images[i].CopyTo(fileStream);
                    }
                }
            }
            catch
            {
                return "Помилка бази даних";
            }

            return "success";
        }

    }
}
