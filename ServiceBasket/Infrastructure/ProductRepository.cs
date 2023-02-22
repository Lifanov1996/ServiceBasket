using Microsoft.EntityFrameworkCore;
using ServiceBasket.Contractes;
using ServiceBasket.Data;
using ServiceBasket.Models;

namespace ServiceBasket.Infrastructure
{
    public class ProductRepository : IProductesRep
    {
        private readonly ContextDB _contextDb;

        public ProductRepository(ContextDB contextDb)
        {
            _contextDb = contextDb;
        }


        public async Task<Product> GetProductAsync(int productId)
        {
            var result = await _contextDb.Products.FindAsync(productId);
            if(result == null)
            {
                throw new ArgumentNullException("The request failed. There is no data in the database for such parameters.");
            }

            return result;
        }


        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _contextDb.Products.AsNoTracking().ToListAsync();
        }


        public async Task<Product> AddProductAsync(Product product)
        {
            await _contextDb.Products.AddAsync(product);
            await _contextDb.SaveChangesAsync();
            return product;
        }


        public async Task<bool> DeleteProductAsync(int productId)
        {
            var result = await _contextDb.Products.SingleOrDefaultAsync(x => x.Id == productId);
            if(result == null )
            {
                throw new ArgumentNullException("The request failed. There is no data in the database for such parameters.");
            }

            _contextDb.Products.Remove(result);
            await _contextDb.SaveChangesAsync();
            return true;
        }
    }
}
