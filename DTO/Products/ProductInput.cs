using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Products
{
    public class ProductInput
    {
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public decimal quantity { get; set; }
        public bool available { get; set; }

    }
}
