using Microsoft.AspNetCore.Mvc;
using MVCModelBindingApp.Models;

namespace MVCModelBindingApp.Controllers
{
    public class PersonController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Person person)
        {
            return View("Result", person);
        }
    }
}