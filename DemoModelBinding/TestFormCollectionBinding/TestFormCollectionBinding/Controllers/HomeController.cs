using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestFormCollectionBinding.Models;

namespace TestFormCollectionBinding.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(IFormCollection fc)//, Student st)
        {
            ViewBag.Id = fc["id"];
            ViewBag.Name = fc["name"];
            ViewBag.Email = fc["email"];

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}