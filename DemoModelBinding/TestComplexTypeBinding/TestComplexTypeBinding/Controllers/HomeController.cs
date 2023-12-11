using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestComplexTypeBinding.Models;

namespace TestComplexTypeBinding.Controllers
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

       // [HttpPost]
       // public IActionResult Submit(Student stu) 
       //{
       //    ViewBag.Id = stu.StudentId;
       //    ViewBag.Name = stu.Name;
       //    ViewBag.Email = stu.Email;
       //    ViewBag.Gender = stu.Gender;
       //    ViewBag.Address = stu.Address;
       //    ViewBag.DateOfBirth = stu.DateOfBirth;

       //    return View("Index");
       // }

        [HttpPost]

        public IActionResult Submit()
        {
           Student stud = new Student();
           stud.Name = Request.Form["Name"].ToString();
           ViewBag.Name = stud.Name;
           return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}