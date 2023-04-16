using AutoMapper;
using Core.Models;
using Core.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;
using WEBUI.Filters;

namespace WebUI.Controllers
{
    //[Authorize(Roles ="admin")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper, ICategoryService categoryService)
        {
            _productService = productService;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            //return View( _mapper.Map<List<ProductVM>>( await _productService.GetAllAsync()));
            return View(await _productService.GetProductsWithCategory());
        }
        public async Task<IActionResult> Save()
        {
            await GetCategoriesAndViewBag();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductVM productVm)
        {
            if (!ModelState.IsValid)
            {
                await GetCategoriesAndViewBag();
                return View();
               
            }
            await _productService.AddAsync(_mapper.Map<Product>(productVm));
            return RedirectToAction(nameof(Index));
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]

        public async Task<IActionResult> Update(int id)
        {
            var product=await _productService.GetByIdAsync(id);
            await GetCategoriesAndViewBag();
            return View(_mapper.Map<ProductVM>(product));
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductVM productVM)
        {
            if (!ModelState.IsValid)
            {
                var product = await _productService.GetByIdAsync(productVM.Id);
                await GetCategoriesAndViewBag();
                return View(_mapper.Map<ProductVM>(product));
            }
            // var product = await _productService.GetByIdAsync(id);

            await _productService.UpdateAsync(_mapper.Map<Product>(productVM));
            return RedirectToAction(nameof(Index));
        }
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            await _productService.RemoveAsync(product);
            return RedirectToAction(nameof(Index));
        }


        [NonAction]
        public async Task GetCategoriesAndViewBag()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoriesVM = _mapper.Map<List<CategoryVM>>(categories);
            ViewBag.Categories = new SelectList(categoriesVM, "Id", "Name");
        }
    }
}
