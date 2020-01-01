using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ReaderWriters
{
    public class CategoryReaderWriter : IDataReaderWriter<CategoryDTO>
    {
        private UnitOfWork unitOfWork;
        private IMapper mapper;

        public CategoryReaderWriter()
        {
            unitOfWork = new UnitOfWork();
            mapper = MapperConfigurationClass.Configure();
        }
        public void Create(CategoryDTO item)
        {
            Category prod = mapper.Map<CategoryDTO, Category>(item);
            unitOfWork.Categories.Create(prod);
        }

        public void Delete(int id)
        {
            unitOfWork.Categories.Delete(id);
        }

        public CategoryDTO Get(int id)
        {
            Category Category = unitOfWork.Categories.Get(id);
            return mapper.Map<Category, CategoryDTO>(Category);
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(unitOfWork.Categories.GetAll());
        }

        public void Update(CategoryDTO item)
        {
            Category prod = mapper.Map<CategoryDTO, Category>(item);
            unitOfWork.Categories.Update(prod);
        }
    }
}
