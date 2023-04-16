using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class BasketItem:BaseEntity
    {
        public int BasketId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public Basket Basket { get; set; }
        public Product Product { get; set; }
    }
}
