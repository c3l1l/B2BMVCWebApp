using Core.Models;
using Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class OrderVM:BaseVM
    {
        public string AppUserId { get; set; }        
        
        public Status Status { get; set; }
        public string Address { get; set; }
        public City City { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        [NotMapped]
        public decimal TotalOrderPrice { get; set; }
    }
}
