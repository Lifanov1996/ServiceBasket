using Microsoft.EntityFrameworkCore;
using ServiceBasket.Contractes;
using ServiceBasket.Data;
using ServiceBasket.Models;

namespace ServiceBasket.Infrastructure.Repositories
{
    public class ProductRepository : IProductesRep
    {
        private readonly ContextDB _contextDb;

        public ProductRepository(ContextDB contextDb)
        {
            _contextDb = contextDb;
        }


        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _contextDb.Products.AsNoTracking().ToListAsync();
        }


        public async Task<Product> AddProductAsync(Product product)
        {
            var isProduct = await _contextDb.Products.SingleOrDefaultAsync(x => x.Name == product.Name.ToUpper().Trim());
            if (isProduct != null) 
            {
                throw new Exception("Товар с таким именем уже доступен");
            }
            await _contextDb.Products.AddAsync(product);
            await _contextDb.SaveChangesAsync();
            return product;
        }


        public async Task<bool> DeleteProductAsync(int productId)
        {
            var result = await _contextDb.Products.SingleOrDefaultAsync(x => x.Id == productId);
            if (result == null)
            {
                throw new Exception("Товар не найден");
            }

            _contextDb.Products.Remove(result);
            await _contextDb.SaveChangesAsync();
            return true;
        }
    }
}
