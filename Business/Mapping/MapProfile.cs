using AutoMapper;
using Core.Models;
using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            // CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Product, ProductVM>().ReverseMap();
            CreateMap<Category,CategoryVM>().ReverseMap();
            CreateMap<Product,ProductWithCategoryVM>().ReverseMap();
            CreateMap<PriceList,PriceListVM>().ReverseMap();    
            CreateMap<BasketItem, BasketItemVM>().ReverseMap();
            CreateMap<Order, OrderVM>().ReverseMap();
            CreateMap<Order, UserOrderVM>().ReverseMap();
            CreateMap<Order,OrderDetailVM>().ReverseMap();
            CreateMap<Order,OrderAdminVM>().ReverseMap();
            CreateMap<Order,OrderAdminDetailVM>().ReverseMap();
            CreateMap<ProductImage,ProductImageVM>().ReverseMap();

        }
    }
}
