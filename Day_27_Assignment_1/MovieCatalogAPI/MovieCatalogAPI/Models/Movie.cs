using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MovieCatalogAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Range(1900, 2100)]
        public int ReleaseYear { get; set; }

        public int DirectorId { get; set; }

        [JsonIgnore]
        public Director? Director { get; set; }
    }
}