using AppLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JettMarketApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PasswordOtpController : ControllerBase
    {
        internal PasswordOtpManager manager = new PasswordOtpManager();

        [HttpPost]
        public IActionResult CreatePasswordOtp(string email)
        {
            try
            {
                manager.CreatePasswordOtp(email);
                return Ok("Otp for password recovery was created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult ValidatePasswordOtp(string email, string otpInput)
        {
            try
            {
                var result = manager.ValidateOtp(email, otpInput);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
