using AppLogic;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JettMarketApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegisterOtpController : ControllerBase
    {
        internal RegisterOtpManager manager = new RegisterOtpManager();

        [HttpPost]
        public IActionResult CreateOtp(string email)
        {
            try
            {
                manager.CreateRegisterOtp(email);
                return Ok("Otp created and sended");
            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult ValidateOtp(string email, string otp)
        {
            try
            {
                var result = manager.ValidateInputOtp(email, otp);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteOtp(string email)
        {
            try
            {
                manager.DeleteRegisterOtp(email);
                return Ok("Otp Deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
