using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Notifications
{
    public class DbNotification
    {
        public int id {  get; set; }
        public string message { get; set; }
        public int idUser { get; set; }
    }
}
