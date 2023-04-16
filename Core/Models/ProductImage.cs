﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ProductImage:BaseEntity
    {
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsMainImage { get; set; }
    }
}
