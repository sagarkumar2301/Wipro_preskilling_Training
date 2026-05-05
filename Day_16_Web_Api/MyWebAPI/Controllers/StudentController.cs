using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        static List<Student> students = new List<Student>()
        {
            new Student { Id = 1, Name = "Sagar" },
            new Student { Id = 2, Name = "Rahul" }
        };

        // GET all
        [HttpGet]
        public List<Student> Get()
        {
            return students;
        }

        // GET by id
        [HttpGet("{id}")]
        public Student GetById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        // POST
        [HttpPost]
        public string Post(Student student)
        {
            students.Add(student);
            return "Student Added";
        }

        // PUT
        [HttpPut("{id}")]
        public string Put(int id, Student updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                student.Name = updatedStudent.Name;
                return "Student Updated";
            }
            return "Student Not Found";
        }

        // DELETE
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
                return "Student Deleted";
            }
            return "Student Not Found";
        }
    }
}