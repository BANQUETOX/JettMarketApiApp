using AppLogic;
using DTO.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JettMarketApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {

        internal NotificationManager manager = new NotificationManager();

        [HttpGet]
        public IActionResult GetAllNotifications()
        {
            try
            {
                var notifications = manager.GetAllNotifications();
                return Ok(notifications);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetUserNotifications(int userId)
        {
            try
            {
                var notifications = manager.GetUserNotifications(userId);
                return Ok(notifications);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateNotification (NotificationInput notification)
        {
            try
            {
                manager.CreateNotification(notification);
                return Ok("Notification created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
