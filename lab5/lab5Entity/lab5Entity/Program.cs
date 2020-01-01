using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.DTO;
namespace lab5Entity
{
    class Program
    {
        static void Main(string[] args)
        {
            /*TasksExecutor executor = new TasksExecutor();
            var products = executor.GetProductsOfCategory("М'ясо");
            foreach (ProductDTO prod in products)
                Console.WriteLine("Supplier Name: {0}  Category Name: {1} Product Name: {2}  Price: {3}",
                    prod?.SupplierDTO?.Name, prod?.CategoryDTO?.Name, prod.Name, prod.Price);
            Console.Read();*/
            UserInterface inter = new UserInterface();
            try
            {
                inter.MainLoop();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                inter.MainLoop();
            }
        }
    }
}
