using DataAccess.Mappers;
using DTO.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class NotificationManager
    {
        internal NotificationMapper mapper =  new NotificationMapper();

        public List<DbNotification> GetAllNotifications()
        {
            return mapper.GetAll();
        }

        public List<DbNotification> GetUserNotifications(int idUser) { 
            return mapper.GetUserNotifications(idUser);
        }

        public void CreateNotification(NotificationInput notification)
        {
            mapper.CreateNotification(notification);
        }
    }
}
