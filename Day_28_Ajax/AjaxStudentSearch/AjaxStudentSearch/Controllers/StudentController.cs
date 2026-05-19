using Microsoft.AspNetCore.Mvc;
using AjaxStudentSearch.Models;

namespace AjaxStudentSearch.Controllers
{
    public class StudentController : Controller
    {
        List<Student> students = new List<Student>()
        {
            new Student
            {
                StudentId = 101,
                Name = "Rahul Sharma",
                Course = "BCA",
                Email = "rahul@gmail.com",
                Phone = "9876543210"
            },

            new Student
            {
                StudentId = 102,
                Name = "Priya Singh",
                Course = "MCA",
                Email = "priya@gmail.com",
                Phone = "9876501234"
            },

            new Student
            {
                StudentId = 103,
                Name = "Amit Kumar",
                Course = "B.Tech",
                Email = "amit@gmail.com",
                Phone = "9123456780"
            },

            new Student
            {
                StudentId = 104,
                Name = "Neha Verma",
                Course = "MBA",
                Email = "neha@gmail.com",
                Phone = "9988776655"
            }
        };

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchStudent(int studentId)
        {
            var student = students
                .FirstOrDefault(s => s.StudentId == studentId);

            if (student == null)
            {
                return NotFound(new
                {
                    message = "Student not found."
                });
            }

            return Json(student);
        }
    }
}