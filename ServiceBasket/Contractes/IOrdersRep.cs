using ServiceBasket.Models;

namespace ServiceBasket.Contractes
{
    public interface IOrdersRep
    {
        Task<Order> GetOrderAsync(int orderId);

        Task<IEnumerable<Order>> GetOrdersAsync();

        Task<Order> AddOrderAsync(Product product);

        Task<Order> AddProductsOrderAsync(int orderId, Product product);

        Task<bool> DeleteOrderAsync(int orderId);
    }
}
