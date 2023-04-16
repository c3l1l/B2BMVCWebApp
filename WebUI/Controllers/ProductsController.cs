using AutoMapper;
using Core.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public ProductsController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View( _mapper.Map<List<ProductVM>>( await _service.GetAllAsync()));
        }
    }
}
