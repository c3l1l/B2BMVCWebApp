using Core.Models.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Order:BaseEntity
    {
        //[ForeignKey("AppUser")]
        public string AppUserId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }
        public string Address { get; set; }
        public City City { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public AppUser AppUser { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
