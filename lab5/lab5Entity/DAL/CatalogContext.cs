using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class CatalogContext:DbContext
    {
        static CatalogContext()
        {
            Database.SetInitializer(new Initializer());
        }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public CatalogContext()
            : base("DBConnection")
        { }
    }
}
