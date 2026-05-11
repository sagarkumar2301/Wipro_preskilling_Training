using Microsoft.AspNetCore.Mvc;

namespace EcommerceRoutingApp.Controllers
{
    public class ProductsController : Controller
    {
        [Route("Products/{category}/{id:int}")]
        public IActionResult Details(string category, int id)
        {
            ViewBag.Category = category;
            ViewBag.ProductId = id;

            return View();
        }

        [Route("Products/Filter/{category:validcategory}/{priceRange}")]
        public IActionResult Filter(string category, string priceRange)
        {
            ViewBag.Category = category;
            ViewBag.PriceRange = priceRange;

            return View();
        }
    }
}