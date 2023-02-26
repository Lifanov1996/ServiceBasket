using System.ComponentModel.DataAnnotations;

namespace ServiceBasket.Models
{
    public class Order2Product
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Введите количество товара!")]
        [Range (1, 100, ErrorMessage = "Недопустимое количество товара")]
        public int Count { get; set; }
    }
}
