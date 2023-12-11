using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Unobtrusive.Ajax.Demo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return SweetAlert("Oops!", "Please enter your name.", "warning");
            }

            return SweetAlert($"Hello {name}", "Message returned from Server!", "success");
        }

        [HttpPost]
        [AjaxOnly] // [AjaxOnly] là một attribute tùy chỉnh để kiểm tra xem yêu cầu đến có phải là Ajax request hay không.
                   // Nếu không phải, action method sẽ trả về một thông báo SweetAlert cảnh báo.
        public IActionResult AjaxMethod(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return SweetAlert("Oops!", "Please enter your name.", "warning");
            }

            return SweetAlert($"Hello {name}", "Message returned from Server!", "success");
        }
        // code hiển thị thông báo SweetAlert
        private IActionResult SweetAlert(string title, string message, string type)
        {
            return Content($"swal ('{title}',  '{message}',  '{type}')", "text/javascript");
        }
    }
}