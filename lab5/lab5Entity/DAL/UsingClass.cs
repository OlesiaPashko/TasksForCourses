using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class UsingClass
    {
        public static void Use()
        {
            using (CatalogContext db = new CatalogContext())
            {
                foreach (Product prod in db.Products.ToList())
                    Console.WriteLine("Supplier Name: {0}  Category Name: {1} Product Name: {2}  Price: {3}",
                        prod?.Supplier.Name, prod?.Category.Name, prod.Name, prod.Price);
                Console.Read();
            }
        }
    }
}
