using Microsoft.AspNetCore.Mvc;

namespace EcommerceFiltersApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return Content("Login Page");
        }
    }
}