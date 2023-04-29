using AutoMapper;
using Business.Services;
using Core.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> Index(int productId)
        {
            var product = await _productService.GetByIdAsync(productId);
            if (product != null)
            {
                var productImages = await _productImageService.Where(p => p.ProductId == productId).ToListAsync();
                ViewBag.ProductId = product.Id;
                return View(_mapper.Map<List<ProductImageVM>>(productImages));
            }
            return RedirectToAction("Index","Products");
        }
           
        [HttpGet]
        public async Task<IActionResult> Save(int productId)
        {
         var product=await _productService.GetByIdAsync(productId);
            if (product != null)
            {
            var productImageVM=new ProductImageAddVM();
                productImageVM.ProductId=productId;
            return View(productImageVM);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Save([FromForm] ProductImageAddVM productImageVM )
        {
            await _productImageService.SaveProductImageToDb(productImageVM);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var productImage = await _productImageService.GetByIdAsync(id);
            if (productImage != null)
            {
               
               await _productImageService.DeleteProductImageToDb(productImage);
            }
            return RedirectToAction(nameof(Index),productImage.ProductId);
        }
    }
}
