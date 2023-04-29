using Core.Models;
using Core.Repositories;
using DataAccess.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ProductImageRepository : GenericRepository<ProductImage>, IProductImageRespository
    {
        public ProductImageRepository(AppDbContext context) : base(context)
        {
        }
    }
}
