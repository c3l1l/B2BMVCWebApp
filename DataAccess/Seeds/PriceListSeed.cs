using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Seeds
{
    public class PriceListSeed : IEntityTypeConfiguration<PriceList>
    {
        public void Configure(EntityTypeBuilder<PriceList> builder)
        {
            builder.HasData(
                new PriceList { Id = 1, Name = "2023 January", Discount = 32 },
                new PriceList { Id = 2, Name = "2023 March", Discount = 27 },
                new PriceList { Id = 3, Name = "2023 April", Discount = 18 }
                );
        }
    }
}
