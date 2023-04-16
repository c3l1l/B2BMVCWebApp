using AutoMapper;
using Core.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IProductService productService, IMapper mapper)
        {
            _logger = logger;
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
           
            return View(await _productService.GetProductsWithCategory());
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public  IActionResult AdminPanel()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(ErrorVM errorVM)
        {
            return View(errorVM);
        }
    }
}