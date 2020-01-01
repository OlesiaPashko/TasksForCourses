using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ReaderWriters
{
    public class ProductReaderWriter : IDataReaderWriter<ProductDTO>
    {
        private UnitOfWork unitOfWork;
        private IMapper mapper;

        public ProductReaderWriter()
        {
            unitOfWork = new UnitOfWork();
            mapper = MapperConfigurationClass.Configure();
        }

        public IEnumerable<ProductDTO> Find(ProductDTO elem)
        {
            IEnumerable<Product> products = unitOfWork.Products.Find(x => x.Id == elem.Id);
            return mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
        }
        public void Create(ProductDTO item)
        {
            Product prod = mapper.Map<ProductDTO, Product>(item);
            unitOfWork.Products.Create(prod);
            unitOfWork.Save();
        }

        public void Delete(int id)
        {
            unitOfWork.Products.Delete(id);
            unitOfWork.Save();
        }

        public ProductDTO Get(int id)
        {
            Product product = unitOfWork.Products.Get(id);
            return mapper.Map<Product, ProductDTO>(product);
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(unitOfWork.Products.GetAll());
        }

        public void Update(ProductDTO item)
        {
            Product prod = mapper.Map<ProductDTO, Product>(item);
            unitOfWork.Products.Update(prod);
            unitOfWork.Save();
        }
    }
}
