using System.ComponentModel.DataAnnotations;

namespace OnlineBookStoreAPI.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Book>? Books { get; set; }
    }
}