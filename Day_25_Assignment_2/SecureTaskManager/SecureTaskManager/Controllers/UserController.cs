using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureTaskManager.Controllers
{
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        public IActionResult TaskList()
        {
            return View();
        }

        [Authorize(Policy = "CanEditTaskPolicy")]
        public IActionResult EditTask()
        {
            return View();
        }
    }
}