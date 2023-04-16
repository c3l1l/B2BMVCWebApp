using AutoMapper;
using Business.Services;
using Core.Models;
using Core.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WEBUI.Filters;

namespace WebUI.Controllers
{
    public class PriceListsController : Controller
    {
        private readonly IPriceListService _priceListService;
        private readonly IMapper _mapper;

        public PriceListsController(IPriceListService priceListService, IMapper mapper)
        {
            _priceListService = priceListService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            // var priceListsVM= _mapper.Map<List<PriceListVM>>()
            var priceLists = await _priceListService.GetAllAsync();
            return View(_mapper.Map<List<PriceListVM>>(priceLists));
        }

        public async Task<IActionResult> Save()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(PriceListVM priceListVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _priceListService.AddAsync(_mapper.Map<PriceList>(priceListVM));
            return RedirectToAction(nameof(Index));
        }
        [ServiceFilter(typeof(NotFoundFilter<PriceList>))]
        public async Task<IActionResult> Update(int id)
        {
            var priceList = await _priceListService.GetByIdAsync(id);
            return View(_mapper.Map<PriceListVM>(priceList));
        }
        [HttpPost]
        public async Task<IActionResult> Update(PriceListVM priceListVM)
        {
            if (!ModelState.IsValid)
            {
                var priceList = await _priceListService.GetByIdAsync(priceListVM.Id);
                return View(_mapper.Map<PriceListVM>(priceList));
            }
            await _priceListService.UpdateAsync(_mapper.Map<PriceList>(priceListVM));
            return RedirectToAction(nameof(Index));
        }
        [ServiceFilter(typeof(NotFoundFilter<PriceList>))]
        public async Task<IActionResult> Remove(int id)
        {
            var priceList = await _priceListService.GetByIdAsync(id);
            await _priceListService.RemoveAsync(priceList);
            return RedirectToAction(nameof(Index));
        }

    }
}
