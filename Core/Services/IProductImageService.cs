using Core.Models;
using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IProductImageService:IGenericService<ProductImage>
    {
        Task SaveProductImageToDb(ProductImageAddVM productImageVM);
        Task DeleteProductImageToDb(ProductImage productImage);
        Task SetMainImage(ProductImage productImage);
    }
}
