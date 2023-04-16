using AutoMapper;
using Core.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Save(BasketAddVM basketVM)
        {
            return null;
        }
    }
}
