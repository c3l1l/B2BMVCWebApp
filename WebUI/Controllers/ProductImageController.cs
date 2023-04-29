using AutoMapper;
using Core.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class ProductImageController : Controller
    {
        private readonly IProductImageService _productImageService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductImageController(IProductImageService productImageService, IProductService productService, IMapper mapper)
        {
            _productImageService = productImageService;
            _productService = productService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Save(int productId)
        {
         var product=await _productService.GetByIdAsync(productId);
            if (product != null)
            {
            var productImageVM=new ProductImageVM();
                productImageVM.ProductId=productId;
            return View(productImageVM);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Save([FromForm] ProductImageVM productImageVM )
        {
            await _productImageService.SaveProductImageToDb(productImageVM);
            return RedirectToAction("Index");
        }
    }
}
