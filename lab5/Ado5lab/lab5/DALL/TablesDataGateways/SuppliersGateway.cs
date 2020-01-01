using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Interfaces;
using DAL.Models;
using System.Data;
using DAL;

namespace DAL.TablesDataGateways
{
    public  class SuppliersGateway:ITableDataGateway<Supplier>
    {
        private  SqlConnection _connection= ConnectionHolder.Connection;
        private CustomMapper mapper = new CustomMapper();

        public Supplier Get(int supplierID)
        {
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Suppliers WHERE SupplierID = {supplierID}", _connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return mapper.TransformToSupplier(ds.Tables[0].Rows[0]);
        }

        public IEnumerable<Supplier> GetAll()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Suppliers", _connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return mapper.TransformToSuppliers(ds.Tables[0].Rows.Cast<DataRow>().ToArray());
        }
        public void Create(Supplier supplier)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Suppliers (supplierID, supplierName) " +
                "VALUES(@supplierID, @supplierName)", _connection);
            command.Parameters.Add(new SqlParameter("@supplierID", supplier.Id));
            command.Parameters.Add(new SqlParameter("@supplierName", supplier.Name));
            command.ExecuteNonQuery();
        }
        public void Update(Supplier supplier)
        {
            SqlCommand command =new SqlCommand(
                    "UPDATE Suppliers SET SupplierName=@supplierName WHERE SupplierID = @supplierID",
                _connection);
            command.Parameters.Add(new SqlParameter("@supplierID", supplier.Id));
            command.Parameters.Add(new SqlParameter("@supplierName", supplier.Name));
            command.ExecuteNonQuery();
        }

        public void Delete(int supplierID)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Suppliers WHERE SupplierID = @supplierID",
                _connection);
            command.Parameters.Add(new SqlParameter("@supplierID", supplierID));
            command.ExecuteNonQuery();
        }
    }
}
