using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTO;
using AutoMapper;
using DAL.Models;

namespace BusinessLayer
{
    public class TasksExecutor
    {
        private UnitOfWork unitOfWork;
        private IMapper mapper;

        public TasksExecutor()
        {
            mapper =  MapperConfigurationClass.Configure();
            unitOfWork = new UnitOfWork();
        }

        public List<ProductDTO> GetProductsOfCategory(string category)
        {
            var categories = mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(unitOfWork.Categories.GetAll());
            var products = mapper.Map<IEnumerable<Product>, List<ProductDTO>>(unitOfWork.Products.GetAll());
            return (from p in products
                    join c in categories on p.CategoryId equals c.Id
             where c.Name == category
             select new ProductDTO
             {
                 Id = p.Id,
                 Name = p.Name,
                 Price = p.Price,
                 CategoryId = p.CategoryId,
                 SupplierId = p.SupplierId
             }).ToList();
        }

        public List<SupplierDTO> GetSuppliersOfProductsOfCategory(string categoryName)
        {
            var categories = mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(unitOfWork.Categories.GetAll());
            var products = mapper.Map<IEnumerable<Product>, List<ProductDTO>>(unitOfWork.Products.GetAll());
            var suppliers = mapper.Map<IEnumerable<Supplier>, List<SupplierDTO>>(unitOfWork.Suppliers.GetAll());
            return (from s in suppliers
                    join p in products on s.Id equals p.SupplierId
                    join c in categories on p.CategoryId equals c.Id
                    where c.Name == categoryName
                    select new SupplierDTO
                    {
                        Id = s.Id,
                        Name = s.Name
                    }).ToList();
        }

        public List<ProductDTO> GetProductsOfSupplier(string supplierName)
        {
            var products = mapper.Map<IEnumerable<Product>, List<ProductDTO>>(unitOfWork.Products.GetAll());
            var suppliers = mapper.Map<IEnumerable<Supplier>, List<SupplierDTO>>(unitOfWork.Suppliers.GetAll());
            return (from s in suppliers
                    join p in products on s.Id equals p.SupplierId
                    where s.Name == supplierName
                    select new ProductDTO
                    {
                        Id = p.Id,
                        Name = p.Name,
                        SupplierId = p.SupplierId,
                        CategoryId=p.CategoryId,
                        Price = p.Price
                    }).ToList();
        }

        public List<ProductDTO> GetProductsByPrice(double price)
        {
            var products = mapper.Map<IEnumerable<Product>, List<ProductDTO>>(unitOfWork.Products.GetAll());
            return (from p in products 
            where p.Price == price
            select new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                SupplierId = p.SupplierId,
                CategoryId = p.CategoryId,
                Price = p.Price
            }).ToList();
        }
    }
}
