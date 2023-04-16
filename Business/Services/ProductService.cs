using AutoMapper;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProductService : GenericService<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public Task<List<ProductWithCategoryVM>> GetProductsWithCategory()
        {
            throw new NotImplementedException();
        }
    }
}
