using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTO;
using AutoMapper;
using DAL;

namespace BusinessLayer
{
    public static class MapperConfigurationClass
    {
        public static IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Supplier, SupplierDTO>()
                    .ForMember(dto => dto.ProductDTOs, opt => opt.MapFrom(entity => entity.Products))
                    .AfterMap((entity, dto) =>
                    {
                        foreach (var dtoProduct in dto.ProductDTOs)
                        {
                            dtoProduct.SupplierDTO = dto;
                        }
                    })
                    .ReverseMap();
                cfg.CreateMap<Category, CategoryDTO>()
                    .ForMember(dto => dto.ProductDTOs, opt => opt.MapFrom(entity => entity.Products))
                    .AfterMap((entity, dto) =>
                    {
                        foreach (var dtoProduct in dto.ProductDTOs)
                        {
                            dtoProduct.CategoryDTO = dto;
                        }
                    })
                    .ReverseMap();
                cfg.CreateMap<Product, ProductDTO>()
                    .ForMember(dto => dto.SupplierDTO, opt => opt.MapFrom(entity => entity.Supplier))
                    .ForMember(dto => dto.CategoryDTO, opt => opt.MapFrom(entity => entity.Category))
                    .ReverseMap();
            }).CreateMapper();
            return config;
        }
    }
}
