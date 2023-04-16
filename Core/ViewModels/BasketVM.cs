using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class BasketVM:BaseVM
    {
        public int CustomerId { get; set; }
        public CustomerVM Customer { get; set; }
        public  List<BasketItem>  BasketItems { get; set; }

    }
}
