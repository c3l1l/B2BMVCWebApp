using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class OrderConfiguration:IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Status).IsRequired().HasMaxLength(200);
            builder.Property(x => x.OrderNumber).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(200);
            builder.Property(x => x.CustomerId).IsRequired();

        }

        
    }
}
