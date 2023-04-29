using AutoMapper;
using Core.Helpers;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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

        public async Task SaveProductImageToDb(ProductImageAddVM productImageVM)
        {
            foreach (var image in productImageVM.Images)
            {
                var fileName=await  _fileService.FileSaveToServer(image,"wwwroot/images/products/");
                //Mapping manually
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
        public async Task DeleteProductImageToDb(ProductImage productImage)
        {
            await _fileService.FileDeleteToServer(productImage.ImageUrl, "wwwroot/images/products/");
             _productImageRepository.Remove(productImage);
            await _unitOfWork.CommitAsync();
        }
        public async Task SetMainImage(ProductImage productImage)
        {
            await SetAllImagesFalse(productImage.ProductId);
            productImage.IsMainImage = true;
            _productImageRepository.Update(productImage);
            await _unitOfWork.CommitAsync();
        }
        private async Task SetAllImagesFalse(int productId)
        {
            var productImages = await _productImageRepository.Where(p => p.ProductId == productId).ToListAsync();
            productImages.ForEach(productImage => { productImage.IsMainImage = false; });
        }
    }
}
