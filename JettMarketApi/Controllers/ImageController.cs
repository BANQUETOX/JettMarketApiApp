using AppLogic;
using DTO.Images;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JettMarketApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        internal ImageManager manager = new ImageManager();

        [HttpPost]
        public IActionResult CreateImage(InputImage image) {
            try
            {
                manager.CreateImage(image);
                return Ok("Image created successfully");
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);  
            }
        }

        [HttpGet]
        public IActionResult GetAllImages()
        {
            try
            {
                var result = manager.GetAllImages();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetProductImages(int idProduct)
        {
            try
            {
                var result = manager.GetProductImages(idProduct);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public IActionResult UpdateImage(DbImage image)
        {
            try
            {
                manager.UpdateImage(image);
                return Ok("Image updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteImage(int id)
        {
            try
            {
                manager.DeleteImage(id);
                return Ok("Image deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
