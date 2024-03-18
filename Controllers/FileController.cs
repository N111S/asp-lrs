using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Nelli_lr7.Controllers
{
    public class FileController : Controller
    {
        [HttpGet]
        public IActionResult DownloadFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DownloadFile(string firstName, string lastName, string fileName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(fileName))
            {
                ModelState.AddModelError("", "Please fill in all fields");
                return View();
            }

            string fileContent = $"First Name: {firstName}\nLast Name: {lastName}";
            var bytes = Encoding.UTF8.GetBytes(fileContent);

            HttpContext.Response.ContentType = "text/plain";
            HttpContext.Response.Headers.Add("Content-Disposition", "attachment; filename=" + fileName + ".txt");
            return File(bytes, "text/plain", fileName + ".txt");
        }
    }
}
