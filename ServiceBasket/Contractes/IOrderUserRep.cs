using ServiceBasket.Models;

namespace ServiceBasket.Contractes
{
    public interface IOrderUserRep
    {
        /// <summary>
        /// Получение информации о заказе
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<IQueryable> GetOrderAsync(int orderId);

        /// <summary>
        /// Добавление товара в заказ
        /// </summary>
        /// <param name="order2Product"></param>
        /// <returns></returns>
        Task AddProductInOrderAsync(Order2Product order2Product);

        /// <summary>
        /// Удаление товара из заказа
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task DeletProductOrderAsync(int orderId, int productId);

        /// <summary>
        /// Удаление заказа
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task DeletOrderAsync(int orderId);
    }
}
