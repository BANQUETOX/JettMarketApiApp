using System.Diagnostics.Contracts;
using AppLogic;
using DTO.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JettMarketApi.Controllers{

    [Route("api/[controller]/[action]")]
    [ApiController]

    public class SpecificationController : ControllerBase
    {
        internal SpecificationManager manager = new SpecificationManager();

        [HttpPost]
        public IActionResult CreateSpecification(InputSpecification specification){
            try{
                manager.CreateSpecification(specification);
                return Ok("Specification created successfully");
            }
            catch(Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult AsingSpecificationToProduct(int idSpecification, int idProdcut){
            try{
                manager.AsingSpecificationToProduct(idSpecification,idProdcut);
                return Ok("Specification asigned successfully");
            }
            catch(Exception ex){
                return BadRequest(ex);
            }
        }


        [HttpPost]
        public IActionResult RemoveSpecificationToProduct(int idSpecification, int idProdcut){
            try{
                manager.RemoveSpecificationFromProduct(idSpecification,idProdcut);
                return Ok("Specification removed successfully");
            }
            catch(Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult GetAllSpecifications(){
            try{
                var result = manager.GetSpecifications();
                return Ok(result);
            }
            catch(Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult GetProductSpecifications(int idProdcut){
            try{
                var result = manager.GetProductSpecification(idProdcut);
                return Ok(result);
            }
            catch(Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public IActionResult UpdateSpecification(DbSpecification specification){
            try{
                manager.UpdtadeSpecification(specification);
                return Ok("Specification updated successfully");
            }
            catch(Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public IActionResult DeleteSpecification(int id){
            try{
                manager.DeleteSpecification(id);
                return Ok("Specification deleted successfully");
            }
            catch(Exception ex){
                return BadRequest(ex);
            }
        }
    }
}