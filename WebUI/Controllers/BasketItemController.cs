using AutoMapper;
using Core.Models;
using Core.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using WEBUI.Filters;

namespace WebUI.Controllers
{
    public class BasketItemController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketItemService _basketItemService;
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketItemController(IProductService productService, IMapper mapper, IBasketService basketService, IBasketItemService basketItemService)
        {
            _productService = productService;
            _mapper = mapper;
            _basketService = basketService;
            _basketItemService = basketItemService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [ServiceFilter(typeof(NotFoundFilter<Product>))]

        public async Task<IActionResult> BasketItemDetail(int productId,string appUserId )
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
                //return View(basketItem);
            }
            return RedirectToAction("Index", "BasketItem");
        }
        [HttpPost]
        public async Task<IActionResult> BasketItemDetail(BasketItemVM basketItemVM)
        {
           var result= await _basketItemService.CheckBasketItemPropertiesOnDB(basketItemVM);
            if (result)
            {
                await _basketItemService.AddAsync(_mapper.Map<BasketItem>(basketItemVM));
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
