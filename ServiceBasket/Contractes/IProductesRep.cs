using ServiceBasket.Models;

namespace ServiceBasket.Contractes
{
    public interface IProductesRep
    {
        /// <summary>
        /// Получение списка товаров
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetProductsAsync();

        /// <summary>
        /// Добавление товара
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<Product> AddProductAsync(Product product);

        /// <summary>
        /// Удаление товара
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<bool> DeleteProductAsync(int productId);
    }
}
