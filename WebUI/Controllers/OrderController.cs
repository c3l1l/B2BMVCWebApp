using AutoMapper;
using Core.Models.Enums;
using Core.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IBasketItemService _basketItemService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper, IBasketItemService basketItemService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _basketItemService = basketItemService;
        }

        public IActionResult Index(int basketId)
        {
            ViewBag.BasketId = basketId;
            return View();
        }
        public async Task<IActionResult> ConfirmOrder(int basketId)
        {
            //var basketItems = await _basketItemService.Where(b => b.BasketId == basketId).ToListAsync();
            var basketItems = await _basketItemService.GetBasketItemsWithProductByBasketId(basketId);    
            ViewBag.BasketItems= basketItems;
            var orderVm = new OrderVM()
            {
                City = City.Istanbul,
                PaymentMethod = PaymentMethod.BankTransfer
            };
            return View(orderVm);
        }
        [HttpPost]
        public IActionResult ConfirmOrder(OrderVM orderVM)
        {
           
            var orderVm = new OrderVM()
            {
                City = City.Istanbul,
                PaymentMethod = PaymentMethod.BankTransfer
            };
            return View(orderVm);
        }
        public IActionResult ConfirmOrderReview(int basketId)
        {
            ViewBag.BasketId = basketId;
            return View();
        }
    }
}
