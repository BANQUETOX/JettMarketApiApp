using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Users
{
    public class UserInput
    {
        public string? email { get; set; }
        public string? name { get; set; }
        public string? lastName { get; set; }
        public DateTime birthDay { get; set; }
        public string password { get; set; }
        
    }
}
