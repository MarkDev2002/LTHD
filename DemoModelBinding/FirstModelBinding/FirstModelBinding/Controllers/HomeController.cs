using FirstModelBinding.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstModelBinding.Controllers
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
        public ActionResult Submit(Product pro)
        {
             //cơ chế để truyền dữ liệu từ Controller đến View.
            ViewBag.Id = pro.Id;
            ViewBag.Name = pro.Name;
            ViewBag.Rate = pro.Rate;
           ViewBag.Rating = pro.Rating;

            // trả về một view có tên "Index"
            // sau khi xử lý dữ liệu từ form, chuyển người dùng đến view "Index" để hiển thị dữ liệu đã xử lý.
            return View("Index");
        }

        //[HttpPost]
        //public ActionResult Submit()
        //{
        //    Product prod = new Product();

        //    prod.Name = Request.Form["Name"].ToString();
        //    ViewBag.Name = prod.Name;
        //    return View("Index");
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}