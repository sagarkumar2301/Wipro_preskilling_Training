using Microsoft.AspNetCore.Mvc;

namespace EcommerceRoutingApp.Controllers
{
    public class CheckoutController : Controller
    {
        [Route("Checkout")]
        public IActionResult Index(bool isLoggedIn = false)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Login");
            }

            return View("Success");
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}