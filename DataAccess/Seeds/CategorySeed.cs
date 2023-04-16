using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                    new Category { Id=1, Name="Confections"},
                    new Category { Id=2, Name="Beverages"},
                    new Category { Id=3, Name="Condiments"},
                    new Category { Id=4, Name="Seafood"},
                    new Category { Id=5, Name="Grains"},
                    new Category { Id=6, Name="Dairy Products"}
                );
        }
    }
}
