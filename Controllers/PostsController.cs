using HouseRentAndSale.DB;
using HouseRentAndSaleWebApp.DB.Entites;
using HouseRentAndSaleWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentAndSaleWebApp.Controllers
{
    public class PostsController : Controller
    {
        private readonly ILogger<PostsController> _logger;

        public PostsController(ILogger<PostsController> logger)
        {
            _logger = logger;
        }




        // GET: Main page (Posts)
        public ActionResult Index()
        {
            return View(new PostsViewModel());
        }

        //  search from Home
        [HttpPost]
        public IActionResult AppendFilter(HomeSearchViewModel home_model)
        {
            PostsViewModel model = new PostsViewModel(home_model);
            return Filter(model);
        }

        //  rent and sale from navigation
        public IActionResult Sale()
        {
            return Filter(new PostsViewModel { operation_type = 1 });
        }
        public IActionResult Rent()
        {
            return Filter(new PostsViewModel { operation_type = 2 });
        }
        //  ---

        [HttpPost]  //  filter publications from DB in list
        public IActionResult Filter(PostsViewModel model)
        {
            List<ObjectEntity>? items;
            using (Context context = new Context())
            {
                items = context.Objects.Where(x =>

                (model.areaId != -1 ? x.areaId == model.areaId : true) &&
                (model.operation_type != -1 ? x.operation_type == model.operation_type : true) &&
                (model.state != "exist" ? x.state == model.state : true) &&
                (model.objtypeId != -1 ? x.objtypeId == model.objtypeId : x.objtypeId != 7) &&

                (model.price_min != null ? x.price >= model.price_min : true) &&
                (model.price_max != null ? x.price <= model.price_max : true) &&

                (model.square_min != null ? x.square >= model.square_min : true) &&
                (model.square_max != null ? x.square <= model.square_max : true) &&

                (model.floor_min != null ? x.floor >= model.floor_min : true) &&
                (model.floor_max != null ? x.floor <= model.floor_max : true)

                ).OrderBy(x => x.creation_datetime).ToList();
            }

            if (items == null) return View("Index", model);


            model.Publications.Clear();
            for (int i = 10 * model.page - 10; i < 10 * model.page; i++)
            {
                if (i >= items.Count) break;

                PublicationViewModel newModel = new PublicationViewModel(items[i]);

                model.Publications.Add(newModel);
            }


            return View("Index", model);
        }


        [HttpPost]
        public ActionResult Details(int id)
        {
            DetailsViewModel model = new DetailsViewModel();
            try
            {
                using (Context context = new Context())
                {
                    ObjectEntity obj = context.Objects.FirstOrDefault(x => x.Id == id);
                    UserEntity? user = context.Users.FirstOrDefault(x => x.Id == obj.userId);

                    PublicationViewModel publication = new PublicationViewModel(obj);

                    model = new DetailsViewModel(publication, user);
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

            Response.Headers.Append("target", "_blank");
            return View("SinglePost", model);
        }


        public IActionResult MyPublications()
        {
            if (!SignInController.isValidCookie(Request))
            {
                return RedirectToAction("DeleteCookie", "SignIn");
            }

            Guid userId = Guid.Parse(Request.Cookies["u"]);

            List<PublicationViewModel> publications = new List<PublicationViewModel>();

            using (Context context = new Context())
            {
                List<ObjectEntity> objects = context.Objects.Where(x => x.userId == userId).ToList();
                foreach (ObjectEntity obj in objects) publications.Add(new PublicationViewModel(obj));
            }

            PostsViewModel model = new PostsViewModel
            {
                Publications = publications
            };

            return View("MyPosts", model);
        }

        [HttpPost]
        public IActionResult UpdateDelete(int id, string action)
        {
            if (action == "updateTime")
            {
                using (Context context = new Context())
                {
                    ObjectEntity? thisObject = context.Objects.FirstOrDefault(x => x.Id == id);
                    if (thisObject != null)
                    {
                        thisObject.creation_datetime = DateTime.Now;

                        context.Objects.Update(thisObject);
                        context.SaveChanges();
                    }
                }
            }
            else if (action == "delete")
            {
                string path = Path.Combine("wwwroot", "publish_images", $"{id}");
                if (Directory.Exists(path)) Directory.Delete(path, true);

                using (Context context = new Context())
                {
                    ObjectEntity? thisObject = context.Objects.FirstOrDefault(x => x.Id == id);
                    if (thisObject != null)
                    {
                        context.Objects.Remove(thisObject);
                        context.SaveChanges();
                    }
                }
            }

            return RedirectToAction("MyPublications");
        }
    }
}
