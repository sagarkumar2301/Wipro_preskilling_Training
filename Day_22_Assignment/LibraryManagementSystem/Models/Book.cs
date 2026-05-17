using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }

        public string Title { get; set; }

        public int AuthorID { get; set; }

        [ForeignKey("AuthorID")]
        public Author Author { get; set; }

        public ICollection<BookGenre> BookGenres { get; set; }
    }
}