using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceBasket.Contractes;
using ServiceBasket.Models;
using System.Net;

namespace ServiceBasket.Controllers
{
    [Route("Products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductesRep _productes;

        public ProductController(IProductesRep productes)
        {
            _productes = productes;
        }

        /// <summary>
        /// Получение списка товаров
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetAllProductsAsync()
        {
            try
            {
                return Ok(await _productes.GetProductsAsync());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Добавление нового товара
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> AddProductAsync(Product product)
        {
            try
            {
                return Ok(await _productes.AddProductAsync(product));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Удаление товара
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpDelete("{productId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeletProductAsync(int productId)
        {
            try
            {
                return await _productes.DeleteProductAsync(productId);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
