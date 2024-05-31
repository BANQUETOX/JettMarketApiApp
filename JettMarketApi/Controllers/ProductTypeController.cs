using AppLogic;
using Azure.Core;
using DTO.ProductTypes;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JettMarketApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        internal ProductTypeManager manager = new ProductTypeManager();

        [HttpPost]
        public IActionResult CreateProductType(InputProductType productType)
        {
            try
            {
                manager.CreateProductType(productType);
                return Ok("Product Type created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllProductTypes()
        {
            try
            {
                var result = manager.GetAllProductTypes();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateProductType(DbProductType productType)
        {
            try
            {
                manager.UpdateProductType(productType);
                return Ok("Product type updated successfully");
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteProductType(int idProductType)
        {
            try
            {
                manager.DeleteProductType(idProductType);
                return Ok("Product Type deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AsingProductType(int idProduct, int idType)
        {
            try
            {
                manager.AsingProductType(idProduct, idType);
                return Ok("Type assigned to product successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult RemoveProductType(int idProduct, int idType)
        {
            try
            {
                manager.RemoveProductType(idProduct, idType);
                return Ok("Type removed from product successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
