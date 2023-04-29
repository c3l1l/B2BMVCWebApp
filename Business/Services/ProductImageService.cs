using AutoMapper;
using Core.Helpers;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using Core.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProductImageService : GenericService<ProductImage>, IProductImageService
    {
        private readonly IProductImageRespository _productImageRepository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        public ProductImageService(IGenericRepository<ProductImage> repository, IUnitOfWork unitOfWork, IProductImageRespository productImageRepository, IMapper mapper, IFileService fileService) : base(repository, unitOfWork)
        {
            _productImageRepository = productImageRepository;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task SaveProductImageToDb(ProductImageVM productImageVM)
        {
            foreach (var image in productImageVM.Images)
            {
                var fileName=await  _fileService.FileSaveToServer(image,"wwwroot/images/products/");
                ProductImage productImage = new()
                {
                    Id = 0,
                    ProductId = productImageVM.ProductId,
                    ImageUrl = fileName,
                    IsMainImage = false
                };
                await _productImageRepository.AddAsync(productImage);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
