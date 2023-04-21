using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class PriceList:BaseEntity
    {
        public string Name { get; set; }
        public decimal Discount { get; set; }
        public List<Product> Products { get; set; }
    }
}
