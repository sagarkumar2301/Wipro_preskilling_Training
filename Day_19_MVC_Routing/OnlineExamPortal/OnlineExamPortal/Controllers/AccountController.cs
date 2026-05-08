using Microsoft.AspNetCore.Mvc;
using OnlineExamPortal.Filters;

namespace OnlineExamPortal.Controllers
{
    public class AccountController : Controller
    {
        // Login Page
        public IActionResult Login()
        {
            return View();
        }

        // Login Action
        [HttpPost]
        public IActionResult Login(string username)
        {
            // Store Session
            HttpContext.Session.SetString("User", username);

            // Store Cookie
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(7);

            Response.Cookies.Append("Theme", "Dark", option);

            return RedirectToAction("Dashboard");
        }

        // Protected Page
        [AuthFilter]
        [LoggingFilter]
        public IActionResult Dashboard()
        {
            ViewBag.User = HttpContext.Session.GetString("User");

            ViewBag.Theme = Request.Cookies["Theme"];

            return View();
        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}