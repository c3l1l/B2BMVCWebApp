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
        public string AppUserId { get; set; }
        public  List<BasketItem>?  BasketItems { get; set; }

    }
}
