using Microsoft.AspNetCore.Mvc;
using Nelli_lr8.Models;

namespace Nelli_lr8.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<ProductViewModel>
        {
                new ProductViewModel { ID = 1, Name = "Burger", Price = 8.49f, CreatedDate = DateTime.Now.AddDays(-10).AddHours(-3).AddMinutes(11) },
                new ProductViewModel { ID = 2, Name = "Pasta", Price = 12.75f, CreatedDate = DateTime.Now.AddDays(-5).AddHours(-12).AddMinutes(47) },
                new ProductViewModel { ID = 3, Name = "Salad", Price = 7.25f, CreatedDate = DateTime.Now.AddDays(-3).AddHours(-8).AddMinutes(35) },
                new ProductViewModel { ID = 4, Name = "Sandwich", Price = 6.99f, CreatedDate = DateTime.Now.AddDays(-1).AddHours(-4).AddMinutes(55) }
        };

            return View(products);
        }
    }
}
