using Core.Models;
using Core.Repositories;
using DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class BasketRepository : GenericRepository<Basket>, IBasketRepository
    {
        public BasketRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Basket> GetBasketByUserId(string userId)
        {
            return await _context.Baskets.Where(b=>b.AppUserId==userId).FirstOrDefaultAsync();
        }
    }
}
