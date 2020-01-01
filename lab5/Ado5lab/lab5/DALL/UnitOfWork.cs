using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.TablesDataGateways;
namespace DAL
{
    public class UnitOfWork
    {
        private SuppliersGateway suppliersGateway;
        private ProductsGateway productsGateway;
        private CategoriesGateway categoriesGateway;

        public ProductsGateway Products
        {
            get
            {
                if (productsGateway == null)
                    productsGateway = new ProductsGateway();
                return productsGateway;
            }
        }

        public SuppliersGateway Suppliers
        {
            get
            {
                if (suppliersGateway == null)
                    suppliersGateway = new SuppliersGateway();
                return suppliersGateway;
            }
        }

        public CategoriesGateway Categories
        {
            get
            {
                if (categoriesGateway == null)
                    categoriesGateway = new CategoriesGateway();
                return categoriesGateway;
            }
        }

    }
}
