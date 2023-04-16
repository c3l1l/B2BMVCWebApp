using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Order:BaseEntity
    {
        public int CustomerId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
