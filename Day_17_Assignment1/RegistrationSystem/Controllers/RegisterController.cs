using Microsoft.AspNetCore.Mvc;
using RegistrationSystem.Models;

namespace RegistrationSystem.Controllers
{
    public class RegisterController : Controller
    {
        // GET METHOD
        public IActionResult Index()
        {
            return View();
        }

        // POST METHOD
        [HttpPost]
        public IActionResult Index(UserRegistration user)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message =
                    "Registration Successful";
            }

            return View();
        }
    }
}