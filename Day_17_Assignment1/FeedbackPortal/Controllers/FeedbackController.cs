using Microsoft.AspNetCore.Mvc;
using FeedbackPortal.Models;

namespace FeedbackPortal.Controllers
{
    public class FeedbackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Feedback Submitted Successfully";
            }

            return View();
        }

        public IActionResult ViewFeedback()
        {
            return View();
        }
    }
}