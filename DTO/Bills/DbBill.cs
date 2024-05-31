using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Bills
{
    public class DbBill
    {
        public int id {  get; set; }
        public float amount { get; set; }
        public int idBillProducts { get; set; }
        public int idUser {  get; set; }
        public bool paid { get; set; }  
    }
}
