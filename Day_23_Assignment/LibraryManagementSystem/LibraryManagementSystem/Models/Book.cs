using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        public int AuthorId { get; set; }

        public int GenreId { get; set; }

        [ForeignKey("AuthorId")]
        public Author? Author { get; set; }

        [ForeignKey("GenreId")]
        public Genre? Genre { get; set; }
    }
}