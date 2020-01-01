using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTO;
using AutoMapper;
using DAL;
using DAL.Models;

namespace BusinessLayer
{
    public static class MapperConfigurationClass
    {
        public static IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Supplier, SupplierDTO>()
                    .ReverseMap();
                cfg.CreateMap<Category, CategoryDTO>()
                    .ReverseMap();
                cfg.CreateMap<Product, ProductDTO>()
                    .ReverseMap();
            }).CreateMapper();
            return config;
        }
    }
}
