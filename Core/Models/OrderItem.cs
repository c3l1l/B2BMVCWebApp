using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class OrderItem:BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
