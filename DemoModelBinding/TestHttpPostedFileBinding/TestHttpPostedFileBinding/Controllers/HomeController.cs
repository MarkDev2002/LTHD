using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestHttpPostedFileBinding.Models;

namespace FileUploadInMVC.Controllers
{
    public class HomeController : Controller
    {
        private IWebHostEnvironment _environment;
        public HomeController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        // upload 1 file và nhiều file
        [HttpPost]
        public IActionResult Submit(List<IFormFile> fromFiles)
        {
            string uploadpath = _environment.WebRootPath; // Đường dẫn tới thư mục gốc 
            string dest_path = Path.Combine(uploadpath, "uploads"); // Đường dẫn tới thư mục "uploads" trong thư mục gốc

            // thư mục "uploads" tồn tại hay chưa. Nếu không tồn tại, thì tạo thư mục.
            if (!Directory.Exists(dest_path))
            {

                Directory.CreateDirectory(dest_path);
            }

            List<string> uploadedFile = new List<string>(); // danh sách để lưu trữ tên các tệp đã tải lên thành công

            foreach (IFormFile file in fromFiles)
            {
                string sourcefile = Path.GetFileName(file.FileName); // Lấy tên của tệp lưu vào biến sourcefile

                // thêm vào trong thư mục "uploads" bằng tệp đã tải lên
                using (FileStream filestream = new FileStream(Path.Combine(dest_path, sourcefile), FileMode.Create))
                {
                    file.CopyTo(filestream); // Sao chép dữ liệu từ tệp mới tải lên vào filestream 
                    uploadedFile.Add(sourcefile); // Thêm tên tệp đã tải lên thành công vào danh sách
                    ViewBag.Message += string.Format("<b>{0}</b> Files Uploaded.<br/>", sourcefile); // thông báo tên các tệp đã tải lên thành công
                }

            }
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
