using AppLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JettMarketApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        RolManager manager = new RolManager();

        [HttpGet]
        public IActionResult GetAllRols()
        {
            try
            {
                var result = manager.GetAllRols();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetRolById(int id)
        {
            try
            {
                var result = manager.GetRolById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AsingAdminRol(int idUser)
        {
            try
            {
                manager.AsingAdminRol(idUser);
                return Ok("Rol Admin successfully asigned to user");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult RemoveAdminRol(int idUser)
        {
            try
            {
                manager.RemoveAdminRol(idUser);
                return Ok("Rol Admin successfully removed from user");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AsingCustomerRol(int idUser)
        {
            try
            {
                manager.AsingCustomerRol(idUser);
                return Ok("Rol Customer successfully asigned to user");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult RemoveCustomerRol(int idUser)
        {
            try
            {
                manager.RemoveCustomerRol(idUser);
                return Ok("Rol Customer successfully removed from user");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }


}
