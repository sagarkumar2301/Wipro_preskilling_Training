using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MovieCatalogAPI.Models
{
    public class Director
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [JsonIgnore]
        public List<Movie>? Movies { get; set; }
    }
}