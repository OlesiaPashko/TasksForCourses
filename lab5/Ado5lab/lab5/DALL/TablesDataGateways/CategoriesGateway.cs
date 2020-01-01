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
using DAL.Interfaces;
namespace DAL.TablesDataGateways
{
    public  class CategoriesGateway : ITableDataGateway<Category>
    {
        private  SqlConnection _connection = ConnectionHolder.Connection;
        private CustomMapper mapper = new CustomMapper();

        public  Category Get(int categoryID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Categories WHERE CategoryID = @categoryID");
            command.Parameters.Add(new SqlParameter("@categoryID", categoryID));
            SqlDataAdapter adapter = new SqlDataAdapter(command.ToString(), _connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return mapper.TransformToCategory(ds.Tables[0].Rows[0]);
        }

        public IEnumerable<Category> GetAll()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Categories", _connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return mapper.TransformToCategories(ds.Tables[0].Rows.Cast<DataRow>().ToArray());
        }
        public void Create(Category category)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Categories (CategoryID, CategoryName) " +
                "VALUES(@categoryID, @categoryName)", _connection);
            command.Parameters.Add(new SqlParameter("@categoryID", category.Id));
            command.Parameters.Add(new SqlParameter("@categoryName", category.Name));
            command.ExecuteNonQuery();
        }
        public void Update(Category category)
        {
            SqlCommand command =
                new SqlCommand(
                    "UPDATE Categories SET CategoryName=@categoryName WHERE CategoryID = @categoryID",
                _connection);
            command.Parameters.Add(new SqlParameter("@categoryID", category.Id));
            command.Parameters.Add(new SqlParameter("@categoryName", category.Name));
            command.ExecuteNonQuery();  
        }

        public void Delete(int categoryID)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Categories WHERE CategoryID = @categoryID", 
                _connection);
            command.Parameters.Add(new SqlParameter("@categoryID", categoryID));
            command.ExecuteNonQuery();
        }
    }
}
