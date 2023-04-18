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
    public class BasketService : GenericService<Basket>, IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        public BasketService(IGenericRepository<Basket> repository, IUnitOfWork unitOfWork, IBasketRepository basketRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<Basket> GetBasketByUserId(string userId)
        {
            var basket=await _basketRepository.GetBasketByUserId(userId);
            if (basket==null)
            {
                var newBasket=new Basket();
                newBasket.AppUserId=userId;
                await _basketRepository.AddAsync(newBasket);
                await _unitOfWork.CommitAsync();
                 
                return newBasket;
            }
            return basket;
        }
    }
}
