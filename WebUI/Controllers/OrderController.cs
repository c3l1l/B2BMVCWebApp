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
        public async Task<IActionResult> OrderDetail(int orderId)
        {
            var order=await _orderService.GetByIdAsync(orderId);
            return View(_mapper.Map<OrderDetailVM>(order));
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
        
        public async Task<IActionResult> ConfirmOrderReview(OrderVM orderVM)
        {        
            return View(orderVM);
        }
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public async Task<IActionResult> ConfirmOrderReviewAndSave(OrderVM orderVM)
        {
            var order = await _orderService.CheckAndCreateOrder(orderVM);
            if (order != null)
            {
                return RedirectToAction(nameof(Index), nameof(Order), new { appUserId = order.AppUserId });
            }
            return OrderError(new OrderErrorVM { Message="Something Went Wrong !!"});
           // return View(orderVM);
        }
        [HttpGet]
        public async Task<IActionResult> CancelOrder(int orderId,string appUserId)
        {
            var order = await _orderService.GetByIdAsync(orderId);
            if (order.Status=="In Progress")
            {
                await _orderService.RemoveAsync(order);
                return RedirectToAction(nameof(Index),new { appUserId=appUserId });
            }

            return OrderError(new OrderErrorVM() { Message = $"({order.OrderNumber}) order cannot cancel ! " }); 
        }

        public IActionResult OrderError(OrderErrorVM orderErrorVM)
        {
            return View(orderErrorVM);
        }
    }
}
