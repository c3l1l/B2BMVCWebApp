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

        }
    }
}
