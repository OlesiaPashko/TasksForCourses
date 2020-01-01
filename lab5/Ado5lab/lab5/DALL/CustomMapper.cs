using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.Models;

namespace DAL
{
    public class CustomMapper
    {
        public Category TransformToCategory(DataRow row)
        {
            return new Category
            {
                Id = row.Field<int>("CategoryID"),
                Name = row.Field<string>("CategoryName")
            };
         }

        public Product TransformToProduct(DataRow row)
        {
            return new Product
            {
                Id = row.Field<int>("ProductID"),
                Name =  row.Field<string>("ProductName"),
                CategoryId = row.Field<int?>("CategoryID"),
                SupplierId = row.Field<int?>("SupplierID"),
                Price = row.Field<decimal?>("Price")
            };
        }

        public Supplier TransformToSupplier(DataRow row)
        {
            return new Supplier
            {
                Id = row.Field<int>("SupplierID"),
                Name = row.Field<string>("SupplierName")
            };
        }
        public List<Category> TransformToCategories(DataRow[] dataRows)
        {
            List<Category> result = new List<Category>();
            foreach(var row in dataRows)
            {
                result.Add(TransformToCategory(row));
            }
            return result;
        }

        public List<Product> TransformToProducts(DataRow[] dataRows)
        {
            List<Product> result = new List<Product>();
            foreach (var row in dataRows)
            {
                result.Add(TransformToProduct(row));
            }
            return result;
        }

        public List<Supplier> TransformToSuppliers(DataRow[] dataRows)
        {
            List<Supplier> result = new List<Supplier>();
            foreach (var row in dataRows)
            {
                result.Add(TransformToSupplier(row));
            }
            return result;
        }
    }
}
