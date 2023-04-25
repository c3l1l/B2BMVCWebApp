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

        public async Task<List<Order>> GetOrdersWithUser()
        {
            // var orders= await _context.Orders.Include(x=>x.AppUser).ToListAsync();
            return await _context.Orders.ToListAsync();
             
        }

        public async Task<Order> GetOrderWithOrderItemsByOrderId(int orderId)
        {
           // var order=await _context.Orders.Include(o=>o.OrderItems).Where(o=>o.Id==orderId).ToListAsync();
            var order=await _context.Orders.Where(o => o.Id == orderId).Include(o=>o.OrderItems).ThenInclude(o=>o.Product).FirstOrDefaultAsync();
            return order;
        }
    }
}
