using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceBasket.Contractes;
using ServiceBasket.Models;
using System.Net;

namespace ServiceBasket.Controllers
{
    [Route("OrderUser")]
    [ApiController]
    public class OrderUserController : ControllerBase
    {
        private readonly IOrderUserRep _orderUsRep;

        public OrderUserController(IOrderUserRep orders)
        {
            _orderUsRep = orders;
        }

        /// <summary>
        /// Получение полной информации о заказе 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpGet("orderId")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetOrderByAsync(int orderId)
        {
            try
            {
                return Ok(await _orderUsRep.GetOrderAsync(orderId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Добавление товара в заказ
        /// </summary>
        /// <param name="order2Product"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> AddProdOrderAsync(Order2Product order2Product)
        {
            try
            {
                await _orderUsRep.AddProductInOrderAsync(order2Product);
                return Ok("Товар добавлен в заказ!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Удаление товара из заказа
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeletProdOrderAsync(int orderId, int productId)
        {
            try
            {
                await _orderUsRep.DeletProductOrderAsync(orderId, productId);
                return Ok("Товар удален из заказа");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Удаление заказа
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpDelete("orderId")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeletOrderAsync(int orderId)
        {
            try
            {
                await _orderUsRep.DeletOrderAsync(orderId);
                return Ok("Заказ удален");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
