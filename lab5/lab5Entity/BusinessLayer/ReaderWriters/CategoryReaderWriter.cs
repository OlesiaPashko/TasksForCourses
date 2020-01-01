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
            unitOfWork.Save();
        }

        public void Delete(int id)
        {
            unitOfWork.Categories.Delete(id);
            unitOfWork.Save();
        }

        public IEnumerable<CategoryDTO> Find(CategoryDTO elem)
        {
            IEnumerable<Category> categories = unitOfWork.Categories.Find(x => x.Id == elem.Id);
            return mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categories);
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
            unitOfWork.Save();
        }
    }
}
