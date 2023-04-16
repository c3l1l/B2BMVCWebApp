using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Customer:BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } //Must be hashed. And remove !
        public byte[]? PasswordSalt { get; set; }
        public byte[]? PasswordHash { get; set; }
        public List<PriceList> PriceLists { get; set; }
        public List<Order> Orders { get; set; }
    }
}
