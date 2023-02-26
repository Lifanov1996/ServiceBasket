using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceBasket.Contractes;
using ServiceBasket.Models;
using System.Net;

namespace ServiceBasket.Controllers
{
    [Route("Orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRep _ordersRep;

        public OrdersController(IOrdersRep orders)
        {
            _ordersRep = orders;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Order), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Order>> GetAllOrdersAsync()
        {
            try
            {
                return Ok(await _ordersRep.GetAllOrdersAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> AddOrderProdAsync(Order2Product order2Product)
        {
            try
            {
                await _ordersRep.AddNewOrderProdAsync(order2Product);
                return Ok("Заказ создан!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }  
    }
}
