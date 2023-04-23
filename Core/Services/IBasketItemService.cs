using Core.Models;
using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IBasketItemService:IGenericService<BasketItem>
    {
        Task<bool> CheckBasketItemPropertiesOnDB(BasketItemVM basketItemVM);
        Task<List<BasketItemVM>> GetBasketItemsWithProductByBasketId(int basketId);

        Task<int> GetBasketItemsCountByUserId(string userId);
        Task RemoveBasketItemsFromBasket(string appUserId);



    }
}
