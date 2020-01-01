using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DataReaderWriter
    {
        /*public DataReaderWriter(string tableName)
        {
            unitOfWork = new UnitOfWork();
            mapper = MapperConfigurationClass.Configure();
        }

        private IDTO dtoChouser(string tableName)
        {
            IDTO dto = new ProductDTO();
            if (tableName == "Categories")
            {
                dto = new CategoryDTO();
            }
            else if (tableName == "Products")
            {
                dto = new ProductDTO();
            }
            else if (tableName == "Suppliers")
            {
                dto = new SupplierDTO();
            }
            return dto;
        }

       
        public IEnumerable<T> SelectAll(string tableName)
        {
            if (tableName == "Categories")
            {
                return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(unitOfWork.Products.GetAll());
            }
            else if (tableName == "Products")
            {
                dto = new ProductDTO();
            }
            else if (tableName == "Suppliers")
            {
                dto = new SupplierDTO();
            }
            
        }*/
    }
}
