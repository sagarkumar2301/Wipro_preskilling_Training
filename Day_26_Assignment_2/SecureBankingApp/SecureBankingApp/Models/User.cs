using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecureBankingApp.Models
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string? PasswordHash { get; set; }

        [Required]
        public string FinancialInfo { get; set; }
    }
}