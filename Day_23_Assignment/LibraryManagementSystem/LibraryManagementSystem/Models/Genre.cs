using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Genre
    {
        public int GenreId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}