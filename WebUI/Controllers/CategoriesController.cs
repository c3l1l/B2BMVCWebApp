using AutoMapper;
using Business.Services;
using Core.Models;
using Core.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using WEBUI.Filters;

namespace WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var categories=await _categoryService.GetAllAsync();

            return View(_mapper.Map<List<CategoryVM>>(categories));
        }

        public async Task<IActionResult> Save()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(CategoryVM categoryVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _categoryService.AddAsync(_mapper.Map<Category>(categoryVM));
            return RedirectToAction(nameof(Index));
        }
        [ServiceFilter(typeof(NotFoundFilter<Category>))]
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);            
            return View(_mapper.Map<CategoryVM>(category));
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryVM categoryVM)
        {
            if (!ModelState.IsValid)
            {
                var category = await _categoryService.GetByIdAsync(categoryVM.Id);
                return View(_mapper.Map<CategoryVM>(category));
            }           
            await _categoryService.UpdateAsync(_mapper.Map<Category>(categoryVM));
            return RedirectToAction(nameof(Index));
        }
        [ServiceFilter(typeof(NotFoundFilter<Category>))]
        public async Task<IActionResult> Remove(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            await _categoryService.RemoveAsync(category);
            return RedirectToAction(nameof(Index));
        }
    }
}
