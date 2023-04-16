using AutoMapper;
using Business.Services;
using Core.Models;
using Core.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using WEBUI.Filters;

namespace WebUI.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var customers=await _customerService.GetAllAsync();
            return View(_mapper.Map<List<CustomerVM>>(customers));
        }

        public async Task<IActionResult> Save()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(CustomerVM customerVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _customerService.AddAsync(_mapper.Map<Customer>(customerVM));
            return RedirectToAction(nameof(Index));
        }
        [ServiceFilter(typeof(NotFoundFilter<Customer>))]
        public async Task<IActionResult> Update(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            return View(_mapper.Map<CustomerVM>(customer));
        }
        [HttpPost]
        public async Task<IActionResult> Update(CustomerVM customerVM)
        {
            if (!ModelState.IsValid)
            {
                var customer = await _customerService.GetByIdAsync(customerVM.Id);
                return View(_mapper.Map<CustomerVM>(customer));
            }
            await _customerService.UpdateAsync(_mapper.Map<Customer>(customerVM));
            return RedirectToAction(nameof(Index));
        }
        [ServiceFilter(typeof(NotFoundFilter<Customer>))]
        public async Task<IActionResult> Remove(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            await _customerService.RemoveAsync(customer);
            return RedirectToAction(nameof(Index));
        }
    }
}
