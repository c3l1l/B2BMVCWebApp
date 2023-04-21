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
        private readonly IOrderNumberService _orderNumberService;

        public OrderController(IOrderService orderService, IMapper mapper, IBasketItemService basketItemService, IOrderNumberService orderNumberService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _basketItemService = basketItemService;
            _orderNumberService = orderNumberService;
        }

        public IActionResult Index(int basketId)
        {
            ViewBag.BasketId = basketId;
            return View();
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
            var order=await CheckAndCreateOrder(orderVM);
            await _orderService.AddAsync(order);
             return RedirectToAction("Index");
            
        }
        public IActionResult ConfirmOrderReview(int basketId)
        {
            ViewBag.BasketId = basketId;
            return View();
        }

        [NonAction]
        public async Task<Order> CheckAndCreateOrder(OrderVM orderVM)
        {
            if (orderVM.Address == null || orderVM.Address == "")
                 RedirectToAction("OrderError");          
            if (orderVM.City == null)
                RedirectToAction("OrderError");
            if (orderVM.PaymentMethod == null )
                RedirectToAction("OrderError");
           var order= _mapper.Map<Order>(orderVM);
            order.Status = "In Progress";
             order.OrderNumber=await _orderNumberService.Generate();           
            return order;
        }
        private IActionResult OrderError()
        {
            return View();
        }
    }
}
