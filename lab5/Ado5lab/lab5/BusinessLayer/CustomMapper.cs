using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BusinessLayer
{
    public class CustomMapper
    {
        public List<Category> TransformToCategory(DataRow[] dataRows)
        {
            List<Category> result = new List<Category>();
            foreach(var row in dataRows)
            {
                result.Add(new Category
                {
                    Id=row.Field<int>("CategoryID"),
                    Name = row.Field<string>("CategoryName")
                });
            }
            return result;
        }

        public List<Product> TransformToProduct(DataRow[] dataRows)
        {
            List<Product> result = new List<Product>();
            foreach (var row in dataRows)
            {
                var Id = row.Field<int>("ProductID");
                var Name = row.Field<string>("ProductName");
                var CategoryId = row.Field<int?>("CategoryID");
                var SupplierId = row.Field<int?>("SupplierID");
                var Price = row.Field<decimal?>("Price");
                result.Add(new Product
                {
                    Id=Id,
                    Name =Name,
                    CategoryId = CategoryId,
                    SupplierId =SupplierId,
                    Price =Price
                });
            }
            return result;
        }

        public List<Supplier> TransformToSupplier(DataRow[] dataRows)
        {
            List<Supplier> result = new List<Supplier>();
            foreach (var row in dataRows)
            {
                result.Add(new Supplier
                {
                    Id = row.Field<int>("SupplierID"),
                    Name = row.Field<string>("SupplierName")
                });
            }
            return result;
        }
    }
}
