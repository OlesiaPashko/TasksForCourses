using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryRepository:IRepository<Category>
    {
        private CatalogContext db;

        public CategoryRepository(CatalogContext context)
        {
            db = context;
        }

        public void Create(Category item)
        {
            db.Categories.Add(item);
        }

        public void Delete(int id)
        {
            Category Category = db.Categories.Find(id);
            if (Category != null)
                db.Categories.Remove(Category);
        }

        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return db.Categories;
        }

        public void Update(Category item)
        {
            Category prod = db.Categories.Find(item);
            if (prod != null)
            {
                prod = item;
            }
            db.SaveChanges();
        }

        public IEnumerable<Category> Find(Func<Category, Boolean> predicate)
        {
            return db.Categories.Where(predicate).ToList();
        }
            
        
    }
}
