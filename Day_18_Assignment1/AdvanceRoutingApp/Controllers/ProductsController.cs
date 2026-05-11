using Microsoft.AspNetCore.Mvc;

namespace AdvancedRoutingApp.Controllers
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
        [Route("Products/Guid/{id:guidcheck}")]
         public IActionResult GuidProduct(string id)
        {
         return Content($"Valid GUID Product ID: {id}");
        }
    }
}