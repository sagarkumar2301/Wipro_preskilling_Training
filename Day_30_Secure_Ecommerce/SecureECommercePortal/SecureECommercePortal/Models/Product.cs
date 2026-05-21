using System.ComponentModel.DataAnnotations;

namespace SecureECommercePortal.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}