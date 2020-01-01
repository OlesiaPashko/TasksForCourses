using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL;
using System.Data;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.TablesDataGateways
{
    public  class ProductsGateway : ITableDataGateway<Product>
    {
        private  SqlConnection _connection = ConnectionHolder.Connection;
        private CustomMapper mapper = new CustomMapper();

        public  Product Get(int productID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Products WHERE ProductID = @productID");
            command.Parameters.Add(new SqlParameter("@productID", productID));
            SqlDataAdapter adapter = new SqlDataAdapter(command.ToString(), _connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return mapper.TransformToProduct(ds.Tables[0].Rows[0]);
        }

        public IEnumerable<Product> GetAll()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Products", _connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return mapper.TransformToProducts(ds.Tables[0].Rows.Cast<DataRow>().ToArray());
        }
        public void Create(Product product)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Products (ProductID, ProductName, CategoryID, Price, SupplierID) " +
                "VALUES(@productID, @productName, @categoryID, @price, @supplierID)", _connection);
            command.Parameters.Add(new SqlParameter("@productID", product.Id));
            command.Parameters.Add(new SqlParameter("@productName", product.Name));
            command.Parameters.Add(new SqlParameter("@categoryID", product.CategoryId));
            command.Parameters.Add(new SqlParameter("@price", product.Price));
            command.Parameters.Add(new SqlParameter("@supplierID", product.SupplierId));
            command.ExecuteNonQuery();
        }
        public void Update(Product product)
        {
            SqlCommand command =
                new SqlCommand(
                    "UPDATE Products SET productName=@productName WHERE ProductID = @productID, CategoryID = @categoryID, " +
                    "Price=@price, SupplierID=@supplierID", _connection);
            command.Parameters.Add(new SqlParameter("@productID", product.Id));
            command.Parameters.Add(new SqlParameter("@productName", product.Name));
            command.Parameters.Add(new SqlParameter("@categoryID", product.CategoryId));
            command.Parameters.Add(new SqlParameter("@price", product.Price));
            command.Parameters.Add(new SqlParameter("@supplierID", product.SupplierId));
            command.ExecuteNonQuery();
        }

        public void Delete(int productID)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Products WHERE ProductID = @productID",
                _connection);
            command.Parameters.Add(new SqlParameter("@productID", productID));
            command.ExecuteNonQuery();
        }
    }
}
