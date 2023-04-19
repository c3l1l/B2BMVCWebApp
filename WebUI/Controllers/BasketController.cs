using AutoMapper;
using Business.Services;
using Core.Models;
using Core.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBUI.Filters;

namespace WebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IBasketItemService _basketItemService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService basketService, IMapper mapper, IBasketItemService basketItemService, IProductService productService)
        {
            _basketService = basketService;
            _mapper = mapper;
            _basketItemService = basketItemService;
            _productService = productService;
        }

        public async Task<IActionResult> Index(string userId)
        {
            
            var basket = await _basketService.GetBasketByUserId(userId);
            var itemCount=await _basketItemService.GetBasketItemsCountByUserId(userId);
            var basketItems=await _basketItemService.GetBasketItemsWithProductByBasketId(basket.Id);
            return View(_mapper.Map<List<BasketItemVM>>(basketItems));
        }
        public IActionResult Save(BasketAddVM basketVM)
        {
            return null;
        }
        [ServiceFilter(typeof(NotFoundFilter<Product>))]

        public async Task<IActionResult> AddProductToBasket(int productId, string appUserId)
        {
            if (appUserId != null)
            {
                var basket = await _basketService.GetBasketByUserId(appUserId);
                var basketItem = new BasketItem();
                basketItem.BasketId = basket.Id;
                basketItem.ProductId = productId;
                basketItem.Quantity = 1;
                basketItem.Product = await _productService.GetByIdAsync(productId);
                return View(_mapper.Map<BasketItemVM>(basketItem));
            }
            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        public async Task<IActionResult> AddProductToBasket(BasketItemVM basketItemVM)
        {
            var result = await _basketItemService.CheckBasketItemPropertiesOnDB(basketItemVM);
            if (result)
            {
                await _basketItemService.AddAsync(_mapper.Map<BasketItem>(basketItemVM));
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public async Task<IActionResult> Remove(int id)
        {
            var userId =await getUserIdByBasketItemId(id);
            var basketItem = await _basketItemService.GetByIdAsync(id);
            await _basketItemService.RemoveAsync(basketItem);
            return RedirectToAction("Index", "Basket", new {userId=userId});
        }

        [NonAction]
        public async Task<string> getUserIdByBasketItemId(int basketItemId)
        {
            var basketItem = await _basketItemService.GetByIdAsync(basketItemId);
            var basket=await _basketService.GetByIdAsync(basketItem.BasketId);
            return basket.AppUserId;
        }
    }
}
