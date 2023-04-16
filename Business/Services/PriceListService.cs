using AutoMapper;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class PriceListService : GenericService<PriceList>, IPriceListService
    {
        private readonly IPriceListRepository _priceListRepository;
        private readonly IMapper _mapper;
        public PriceListService(IGenericRepository<PriceList> repository, IUnitOfWork unitOfWork, IPriceListRepository priceListRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _priceListRepository = priceListRepository;
            _mapper = mapper;
        }


    }
}
