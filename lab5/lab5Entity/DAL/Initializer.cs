using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Initializer : DropCreateDatabaseAlways<CatalogContext>
    {
        protected override void Seed(CatalogContext db)
        {
            Category cat1 = new Category { Name = "Молочні продукти" };
            Category cat2 = new Category { Name = "М'ясо" };
            db.Categories.AddRange(new List<Category> { cat1, cat2 });
            db.SaveChanges();

            Supplier sup1 = new Supplier { Name = "Постачальник1" };
            Supplier sup2 = new Supplier { Name = "Постачальник2" };
            db.Suppliers.AddRange(new List<Supplier> { sup1, sup2 });
            db.SaveChanges();

            Product prod1 = new Product { Name = "prod1", Price = 12.5, Category = cat1, Supplier = sup1 };
            Product prod2 = new Product { Name = "prod2", Price = 13.5, Category = cat2, Supplier = sup2 };
            db.Products.AddRange(new List<Product> { prod1, prod2 });
            db.SaveChanges();
        }
    }
}
