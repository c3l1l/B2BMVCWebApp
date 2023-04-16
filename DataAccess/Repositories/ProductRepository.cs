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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public Task<List<Product>> GetProductsWithCategory()
        {
            throw new NotImplementedException();
        }
    }
}
