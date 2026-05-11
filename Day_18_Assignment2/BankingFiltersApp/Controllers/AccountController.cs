using Microsoft.AspNetCore.Mvc;

namespace BankingFiltersApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return Content("Login Page");
        }
    }
}