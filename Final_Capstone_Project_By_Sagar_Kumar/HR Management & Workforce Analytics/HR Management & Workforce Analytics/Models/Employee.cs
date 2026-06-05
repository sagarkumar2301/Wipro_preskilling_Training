using System.ComponentModel.DataAnnotations;

namespace HR_Management___Workforce_Analytics.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Department { get; set; }

        public string Designation { get; set; }

        public DateTime JoiningDate { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
