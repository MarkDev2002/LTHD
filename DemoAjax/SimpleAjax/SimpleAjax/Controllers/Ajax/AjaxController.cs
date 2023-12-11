using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace SimpleAjax.Controllers.Ajax
{
    public class AjaxController : Controller
    {
        // đại diện cho cơ sở dữ liệu và được sử dụng để tương tác với cơ sở dữ liệu
        private readonly ApplicationDbContext _context; 

        public AjaxController(ApplicationDbContext context)
        { 
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult EmployeeList() // // trả về dữ liệu Json thay vì View như thông thường
        {
            var data = _context.employees.ToList();

            // truy vấn từ Db bằng ToList() và trả về object JsonResult chứa dữ liệu.
            return new JsonResult(data); 
        }


    }
}
