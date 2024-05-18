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
            return View("Index", new PostsViewModel
            {
                operation_type = 1
            });
        }
        public IActionResult Rent()
        {
            return View("Index", new PostsViewModel
            {
                operation_type = 2
            });
        }
        //  ---

        [HttpPost]  //  filter publications from DB in list
        public IActionResult Filter(PostsViewModel model)
        {
            List<ObjectEntity>? items;
            using(Context context = new Context())
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

            if(items == null) return View("Index", model);


            model.Publications.Clear();
            for(int i = 10*model.page - 10; i < 10*model.page; i++)
            {
                if (i >= items.Count) break;

                PublicationViewModel newModel = new PublicationViewModel(items[i]);

                List<string> images_pathes = Directory.GetFiles(Path.Combine("wwwroot", "publish_images", $"{items[i].Id}")).ToList();

                if (images_pathes.Count == 0) newModel.images_pathes.Add(Path.Combine("wwwroot", "img", "no_image.jpg"));
                else
                {
                    images_pathes = images_pathes.Select(x => x.Replace("wwwroot\\", "/").Replace("\\", "/")).ToList();
                    newModel.images_pathes.AddRange(images_pathes);
                }

                model.Publications.Add(newModel);
            }


            return View("Index", model);
        }


        [HttpPost]
        public ActionResult Details(int id)
        {
            DetailsViewModel model = new DetailsViewModel
            {

            };


            return View("SinglePost", model);
        }

        
    }
}
