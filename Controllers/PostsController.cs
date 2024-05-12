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




        // GET: PostsController
        public ActionResult Index()
        {
            return View(new PostsViewModel());
        }

        public IActionResult AppendFilter(HomeSearchViewModel model)
        {
            return View("Index", new PostsViewModel(model));
        }

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


        // GET: PostsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        
    }
}
