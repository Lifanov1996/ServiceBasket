using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using ServiceBasket.Contractes;
using ServiceBasket.Data;
using ServiceBasket.Models;
using System.Text.Json.Serialization;

namespace ServiceBasket.Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRep
    {
        private readonly ContextDB _contextDb;

        public OrdersRepository(ContextDB contextDb)
        {
            _contextDb = contextDb;         
        }


        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _contextDb.Orders.AsNoTracking().ToListAsync();
        }


        public async Task AddNewOrderProdAsync(Order2Product order2Product)
        {
            var product = await _contextDb.Products.FindAsync(order2Product.ProductId);
            if(product == null)
            {
                throw new Exception("Товара не найден");
            }

            //Создание нового заказа
            await _contextDb.Orders.AddAsync(new Order { AddOrderDT = DateTime.Now.ToString("G") });
            await _contextDb.SaveChangesAsync();

            var order =  await _contextDb.Orders.OrderByDescending(x => x.Id).FirstOrDefaultAsync();

            //Добавление товара в новый заказ
            var orderProd = new Order2Product
            {
                OrderId = order.Id,
                ProductId = order2Product.ProductId,
                Count = order2Product.Count
            };

            await _contextDb.Orders2Products.AddAsync(orderProd);
            await _contextDb.SaveChangesAsync();
        }     
    }
}
