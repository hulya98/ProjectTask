using AutoMapper;
using ProjectTask.Domains.Dtos;
using ProjectTask.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask.Domains.MappingProfile
{
    public class ProductCategoryProfile:Profile
    {
        public ProductCategoryProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
        }
    }
}
