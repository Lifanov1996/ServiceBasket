using System.ComponentModel.DataAnnotations;

namespace ServiceBasket.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string AddOrderDT { get; set; }
    }
}
