using ServiceBasket.Models;

namespace ServiceBasket.Contractes
{
    public interface IOrdersRep
    {      
        /// <summary>
        /// Получить список заказов
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Order>> GetAllOrdersAsync();

        /// <summary>
        /// Создание нового заказа
        /// </summary>
        /// <param name="order2Product"></param>
        /// <returns></returns>
        Task AddNewOrderProdAsync(Order2Product order2Product);
    }
}
