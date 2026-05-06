using CourseRegistrstionApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseRegistrstionApp.Controllers
{
    public class StudentController : Controller
    { //here we will define all the action methods or Student model class 

        //GET for ( One Way data binding  + Routing )

        public IActionResult Register()
        {
            return View();// we will be ceating vie here and hence returning 
        }

        //For two way data binding 
        [HttpPost]
        public IActionResult Register(Student model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }
            ViewBag.Message = " Registeration sucessfull...!!";
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
