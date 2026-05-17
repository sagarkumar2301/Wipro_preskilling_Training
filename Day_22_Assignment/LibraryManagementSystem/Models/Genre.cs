using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Genre
    {
        [Key]
        public int GenreID { get; set; }

        [Required]
        public string? GenreName { get; set; }

        public ICollection<BookGenre>? BookGenres { get; set; }
    }
}