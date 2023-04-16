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
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, CategoryId = 6, Name = "Cheese 1Kg", Price = (decimal)10.99 },
                new Product { Id = 2, CategoryId = 5, Name = "Breads Package", Price = (decimal)3.99 },
                new Product { Id = 3, CategoryId = 4, Name = "Fish Salmon 1Kg", Price = (decimal)18.19 },
                new Product { Id = 4, CategoryId = 1, Name = "Desserts Package x 5", Price = (decimal)8.00 },
                new Product { Id = 5, CategoryId = 1, Name = "Candie Box", Price = (decimal)7.29 },
                new Product { Id = 6, CategoryId = 5, Name = "Pasta Package x 10", Price = (decimal)18.99 },
                new Product { Id = 7, CategoryId = 1, Name = "Desserts Salmon 1 Kg", Price = (decimal)18.99 },
                new Product { Id = 8, CategoryId = 4, Name = "Wild Dorade 1 Piece(600-700 gr)", Price = (decimal)18.99 }

            );
        }
    }
}
