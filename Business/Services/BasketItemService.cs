using AutoMapper;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class BasketItemService : GenericService<BasketItem>, IBasketItemService
    {
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public BasketItemService(IGenericRepository<BasketItem> repository, IUnitOfWork unitOfWork, IMapper mapper, IBasketRepository basketRepository, IProductRepository productRepository, IBasketItemRepository basketItemRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _basketRepository = basketRepository;
            _productRepository = productRepository;
            _basketItemRepository = basketItemRepository;
        }

        public async Task<bool> CheckBasketItemPropertiesOnDB(BasketItemVM basketItemVM)
        {
            if (!await _productRepository.AnyAsync(p => p.Id == basketItemVM.ProductId))
            {
                return false;
            }          
            if (!await _basketRepository.AnyAsync(b => b.Id == basketItemVM.BasketId))
            {
                return false;
            }
            return true;
        }

        public async Task<List<BasketItemVM>> GetBasketItemsWithProductByBasketId(int basketId)
        {
            var basketItems=await _basketItemRepository.GetBasketItemsWithProductByBasketId(basketId);
            return _mapper.Map<List<BasketItemVM>>(basketItems);
        }
    }
}
