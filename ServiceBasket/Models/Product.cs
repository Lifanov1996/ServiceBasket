using System.ComponentModel.DataAnnotations;

namespace ServiceBasket.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название товара")]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите сумму товара")]
        [Range(1d, 100000d, ErrorMessage = "Максимальная сумма товара в магазине не более 100000")]
        public decimal Price { get; set; }
    }
}
