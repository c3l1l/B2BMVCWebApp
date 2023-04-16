using AutoMapper;
using Core.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
    }
}
