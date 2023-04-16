using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class PriceListVM:BaseVM
    {
        public string Name { get; set; }
        public decimal Discount { get; set; }
    }
}
