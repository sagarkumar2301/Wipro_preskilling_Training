using BankingFiltersApp.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BankingFiltersApp.Controllers
{
    [ServiceFilter(typeof(AuthFilter))]
    public class BankingController : Controller
    {
        public IActionResult Account()
        {
            return Content("User Account Details");
        }

        public IActionResult Transactions()
        {
            return Content("Transaction History");
        }

        [ServiceFilter(typeof(AdminAuthorizationFilter))]
        public IActionResult AdminPanel()
        {
            return Content("Admin Access Granted");
        }

        public IActionResult Transfer()
        {
            return Content("Money Transfer Successful");
        }

        public IActionResult ErrorTest()
        {
            throw new Exception("Banking Exception");
        }
    }
}