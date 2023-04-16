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
    public class PriceListRepository : GenericRepository<PriceList>, IPriceListRepository
    {
        public PriceListRepository(AppDbContext context) : base(context)
        {
        }
    }
}
