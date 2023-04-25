using AutoMapper;
using Core.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
   // [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public AdminController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Order()
        {
            var orders=await _orderService.GetOrdersWithUser();
            return View(_mapper.Map<List<OrderAdminVM>>(orders));
        }
        public async Task<IActionResult> OrderDetail(int orderId)
        {
            var orderDetail = await _orderService.GetOrderWithOrderItemsByOrderId(orderId);
            return View(_mapper.Map<OrderAdminDetailVM>(orderDetail));
        }
        public async Task<IActionResult> ConfirmOrder(int orderId)
        {
            var order=await _orderService.GetByIdAsync(orderId);
            _orderService.ChangeOrderStatus(order);
           return RedirectToAction(nameof(OrderDetail), new {orderId=orderId});
        }
        public async Task<IActionResult> CancelOrder(int orderId)
        {
            var order = await _orderService.GetByIdAsync(orderId);
            await _orderService.CancelOrder(order);
            return RedirectToAction(nameof(OrderDetail),new {orderId=orderId});
        }

    }
}
