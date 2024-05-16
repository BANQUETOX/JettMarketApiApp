using AppLogic;
using Azure.Core;
using DTO.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JettMarketApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager manager = new UserManager();


        [HttpPost]
        public IActionResult CreateUser(UserInput newUser)
        {
            try
            {
                manager.CreateUser(newUser);
                return Ok("User created successfully");

            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public  IActionResult GetUserById(int id)
        {
            try
            {
                DbUser user = manager.GetUserById(id).GetAwaiter().GetResult();
                return Ok(user);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public  IActionResult GetUserByEmail(string email) {
            try
            {
                DbUser user =  manager.GetUserByEmail(email).GetAwaiter().GetResult();
                return Ok(user);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateUser(DbUser user)
        {
            try
            {
                manager.UpdateUser(user);
                return Ok("User updated successfully");
            }
            catch (Exception ex) { 
               
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete] 
        public IActionResult deleteUser(int id)
        {
            try
            {
                manager.DeleteUser(id);
                return Ok("User deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Login(string email, string password)
        {
            try
            {
                var result = manager.Login(email,password);
                return Ok(result.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
