using AutoMapper;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public IActionResult Index(int basketId)
        {
            ViewBag.BasketId = basketId;
            return View();
        }
        public IActionResult ConfirmOrder(int basketId)
        {
            ViewBag.BasketId = basketId;
            return View();
        }
    }
}
