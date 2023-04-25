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
    public class OrderAdminVM:BaseVM
    {
        public string AppUserId { get; set; }

        public string Status { get; set; }
        public string Address { get; set; }
        public City City { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public AppUser  AppUser { get; set; }

        [NotMapped]
        public decimal TotalOrderPrice { get; set; }
    }
}
