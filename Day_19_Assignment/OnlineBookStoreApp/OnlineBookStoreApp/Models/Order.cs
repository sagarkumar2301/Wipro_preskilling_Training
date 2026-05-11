using System.ComponentModel.DataAnnotations;

namespace OnlineBookStoreApp.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string CustomerName { get; set; }

        public decimal TotalAmount { get; set; }
    }
}