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
    public class BasketItemRepository : GenericRepository<BasketItem>, IBasketItemRepository
    {
        public BasketItemRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<List<BasketItem>> GetBasketItemsWithProductByBasketId(int basketId)
        {
            return await _context.BasketItems.Include(x => x.Product).Where(x=>x.BasketId==basketId).ToListAsync();
        }
    }
}
