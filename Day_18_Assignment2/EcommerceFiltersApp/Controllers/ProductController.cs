using EcommerceFiltersApp.Filters;
using Microsoft.AspNetCore.Mvc;
using ServiceFilterAttribute = Microsoft.AspNetCore.Mvc.ServiceFilterAttribute;

namespace EcommerceFiltersApp.Controllers
{
    [ServiceFilter(typeof(AuthFilter))]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return Content("Product Page");
        }

        public IActionResult Details()
        {
            return Content("Product Details");
        }

        public IActionResult ErrorTest()
        {
            throw new Exception("Test Exception");
        }
    }
}