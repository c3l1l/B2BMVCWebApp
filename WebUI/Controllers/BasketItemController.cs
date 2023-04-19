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

       
    }
}
