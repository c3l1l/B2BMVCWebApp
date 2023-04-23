using AutoMapper;
using Core.Helpers;
using Core.Models;
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
        private readonly IOrderItemService _orderItemService;

        public OrderController(IOrderService orderService, IMapper mapper, IBasketItemService basketItemService, IOrderItemService orderItemService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _basketItemService = basketItemService;
            _orderItemService = orderItemService;
        }

        public async Task<IActionResult> Index(string appUserId)
        {
            var userOrders= await _orderService.Where(o => o.AppUserId == appUserId).ToListAsync();

            return View(_mapper.Map<List<UserOrderVM>>(userOrders));
        }
        public async Task<IActionResult> ConfirmOrder(int basketId)
        {
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
        public async Task<IActionResult> ConfirmOrder(OrderVM orderVM)
        {
            var order=await _orderService.CheckAndCreateOrder(orderVM);
            if (order!=null) {
                return RedirectToAction(nameof(Index), nameof(Order), new { appUserId = order.AppUserId });
            }          
            return  RedirectToAction(nameof(OrderError));
        }
        public IActionResult ConfirmOrderReview(int basketId)
        {
            ViewBag.BasketId = basketId;
            return View();
        }
       
        public IActionResult OrderError()
        {
            return View();
        }
    }
}
