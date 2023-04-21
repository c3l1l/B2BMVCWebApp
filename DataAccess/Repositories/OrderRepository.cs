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
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Order> GetLastOrder()
        {
            return await _context.Orders.OrderBy(o => o.Id).LastOrDefaultAsync();
        }
    }
}
