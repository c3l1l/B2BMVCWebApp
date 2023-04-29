using Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class ProductImageAddVM:ProductImage
    {
        public IFormFile[] Images { get; set; }

    }
}
