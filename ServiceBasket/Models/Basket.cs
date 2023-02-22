namespace ServiceBasket.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public List<QuantityProducts>? Products { get; set; }
    }
}
