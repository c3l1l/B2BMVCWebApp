using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class BasketItemVM:BaseVM
    {
        public int BasketId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public Product Product { get; set; }
    }
}
