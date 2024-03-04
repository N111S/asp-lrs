using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Nelli_lr5.Controllers
{
	public class DataController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
        public IActionResult ThrowException()
        {
            string message = "Test Exception";
            try
            {
                throw new Exception(message);
            }
            catch (Exception ex)
            {
                LogError(ex, message);
                throw;
            }
        }
        private void LogError(Exception ex, string message)
        {
            string errorMessage = $"[{DateTime.UtcNow}] {message}\n{ex.ToString()}\n";
        }
        public IActionResult StoreData(string value, DateTime expirationDate)
		{
			Response.Cookies.Append("storedData", value, new CookieOptions
			{
				Expires = expirationDate
			});
			return RedirectToAction("CheckData");
		}

		public IActionResult CheckData()
		{
			var storedData = Request.Cookies["storedData"];
			return Content($"Data: {storedData}");
		}
	}
}