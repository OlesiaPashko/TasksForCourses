using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SupplierRepository:IRepository<Supplier>
    {
        private CatalogContext db;

        public SupplierRepository(CatalogContext context)
        {
            db = context;
        }

        public void Create(Supplier item)
        {
            db.Suppliers.Add(item);
        }

        public void Delete(int id)
        {
            Supplier Supplier = db.Suppliers.Find(id);
            if (Supplier != null)
                db.Suppliers.Remove(Supplier);
        }

        public Supplier Get(int id)
        {
            return db.Suppliers.Find(id);
        }

        public IEnumerable<Supplier> GetAll()
        {
            return db.Suppliers;
        }

        public void Update(Supplier item)
        {
            Supplier prod = db.Suppliers.Find(item);
            if (prod != null)
            {
                prod = item;
            }
            db.SaveChanges();
        }
        public IEnumerable<Supplier> Find(Func<Supplier, Boolean> predicate)
        {
            return db.Suppliers.Where(predicate).ToList();
        }
    }
}
