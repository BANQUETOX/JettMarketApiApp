using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Bills
{
    public class InputBill
    {
        public float amount {  get; set; }
        public int idUser {  get; set; }
        public bool paid { get; set; }
    }
}
