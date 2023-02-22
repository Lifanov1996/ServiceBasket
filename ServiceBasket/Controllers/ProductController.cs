using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceBasket.Contractes;
using ServiceBasket.Models;
using System.Net;

namespace ServiceBasket.Controllers
{
    [Route("Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductesRep _productes;

        public ProductController(IProductesRep productes)
        {
            _productes = productes;
        }


        [HttpGet("{productId}")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetAsync(int productId)
        {
            try
            {
                return Ok( await _productes.GetProductAsync(productId));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


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


        [HttpDelete("{productId}")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
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
