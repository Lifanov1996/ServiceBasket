using Microsoft.EntityFrameworkCore;
using ServiceBasket.Contractes;
using ServiceBasket.Data;
using ServiceBasket.Models;

namespace ServiceBasket.Infrastructure.Repositories
{
    public class OrderUserRepository : IOrderUserRep
    {
        private readonly ContextDB _contextDb;
        private Order2Product _model;

        public OrderUserRepository(ContextDB contextDb)
        {
            _contextDb = contextDb;           
        }


        public async Task<IQueryable> GetOrderAsync(int orderId)
        {
            var order = await _contextDb.Orders.FindAsync(orderId);
            if (order == null)
            {
                throw new Exception("Ошибка! Заказ не найден!");
            }
            var result = _contextDb.Orders2Products.Where(x => x.OrderId == orderId).
                                                        Join(_contextDb.Orders,
                                                             op => op.OrderId,
                                                             or => or.Id,
                                                             (op, or) => new
                                                             {
                                                                 op.OrderId,
                                                                 op.ProductId,
                                                                 op.Count,
                                                                 or.AddOrderDT
                                                             }).Join(_contextDb.Products,
                                                             op => op.ProductId,
                                                             pr => pr.Id,
                                                             (op, pr) => new
                                                             {
                                                                 op.OrderId,
                                                                 op.AddOrderDT,
                                                                 pr.Name,
                                                                 pr.Price,
                                                                 op.Count
                                                             });
            return result;
        }


        public async Task AddProductInOrderAsync(Order2Product order2Product)
        {
            var order = await _contextDb.Orders.FindAsync(order2Product.OrderId);
            if (order == null)
            {
                throw new Exception("Заказ не найден!");
            }
            var product = await _contextDb.Products.FindAsync(order2Product.ProductId);
            if (product == null)
            {
                throw new Exception("Товара не найден!");
            }

            var isProdOrder = await _contextDb.Orders2Products.SingleOrDefaultAsync(x => x.ProductId == order2Product.ProductId && x.OrderId == order2Product.OrderId);
            if (isProdOrder != null)
            {
                throw new Exception("Товар уже есть в заказе! Чтобы обновить заказ, удалите старый товар");
            }

            await _contextDb.Orders2Products.AddAsync(order2Product);
            await _contextDb.SaveChangesAsync();
        }


        public async Task DeletProductOrderAsync(int orderId, int productId)
        {           
            var result = await _contextDb.Orders2Products.SingleOrDefaultAsync(x => x.OrderId == orderId && x.ProductId == productId);
            if (result == null)
            {
                throw new Exception("Ошибка удаления товара!");
            }
            _contextDb.Orders2Products.Remove(result);
            await _contextDb.SaveChangesAsync();
        }


        public async Task DeletOrderAsync(int orderId)
        {
            var order = await _contextDb.Orders.FindAsync(orderId);
            if (order == null)
            {
                throw new Exception("Заказ не найден!");
            }

            _contextDb.Orders.Remove(order);

            var result = await _contextDb.Orders2Products.Where(x => x.OrderId == orderId).ToListAsync();            
            _contextDb.Orders2Products.RemoveRange(result);           

            await _contextDb.SaveChangesAsync();
        }
    }
}
