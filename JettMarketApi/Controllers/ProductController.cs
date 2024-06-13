using AppLogic;
using DTO.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JettMarketApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        internal ProductManager manager = new ProductManager();
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                var result = manager.GetAllProducts();
                return Ok(result);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetInStockProduct()
        {
            try
            {
                var result = manager.GetProductsInStock();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAvailableProducts()
        {
            try
            {
                var result = manager.GetProductsAvailable();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetProductsInStrockAvailables()
        {
            try
            {
                var result = manager.GetProductsInStockAvailables();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductInput product)
        {
            try
            {
                manager.CreateProduct(product);
                return Ok("Product created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateProduct(DbProduct product)
        {
            try
            {
                manager.UpdateProduct(product);
                return Ok("Product updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                manager.DeleteProduct(id);
                return Ok("Product deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
