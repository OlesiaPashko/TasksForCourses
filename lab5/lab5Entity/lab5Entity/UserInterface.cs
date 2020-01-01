using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using BusinessLayer.ReaderWriters;

namespace lab5Entity
{
    public class UserInterface
    {
        private TasksExecutor exec;
        public UserInterface()
        {
            exec = new TasksExecutor();
        }

        public void ExecuteTasks()
        {
            Console.WriteLine("Press number of task (1 - Get Products Of Category, 2 - Get Suppliers Of Products of some category, " +
                "3 - Get Products Of Supplier , 4 - Get Product By Price)");
            int chouse = Int32.Parse(Console.ReadLine());
            switch (chouse)
            {
                case 1:
                    {
                        Console.WriteLine("Enter Category Name");
                        string name = Console.ReadLine();
                        var res = exec.GetProductsOfCategory(name);
                        foreach (var elem in res)
                        {
                            Console.WriteLine(elem);
                        }
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Enter Category Name");
                        string name = Console.ReadLine();
                        var res = exec.GetSuppliersOfProductsOfCategory(name);
                        foreach (var elem in res)
                        {
                            Console.WriteLine(elem);
                        }
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Enter Supplier Name");
                        string name = Console.ReadLine();
                        var res = exec.GetProductsOfSupplier(name);
                        foreach (var elem in res)
                        {
                            Console.WriteLine(elem);
                        }
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Please enter the price");
                        double price = Double.Parse(Console.ReadLine());
                        var res = exec.GetProductsByPrice(price);
                        foreach (var elem in res)
                        {
                            Console.WriteLine(elem);
                        }
                        break;
                    }
            }
        }

        public void MainLoop()
        {
            while (true)
            {
                Console.WriteLine("Press 1 to execute one of tasks or 2 to manage one of tables ");
                int chouse = Int32.Parse(Console.ReadLine());
                if (chouse == 1)
                {
                    ExecuteTasks();
                }
                else if (chouse == 2)
                {
                    Console.WriteLine("1 to manage Suppliers, 2 to manage Categories, 3 to manage Products");
                    int chouse2 = Int32.Parse(Console.ReadLine());
                    switch (chouse2)
                    {
                        case 1:
                            {
                                SupplierReaderWriter readerWriter = new SupplierReaderWriter();
                                DTOsManager<SupplierDTO>.ManageTable(readerWriter);
                                break;
                            }
                        case 2:
                            {
                                CategoryReaderWriter readerWriter = new CategoryReaderWriter();
                                DTOsManager<CategoryDTO>.ManageTable(readerWriter);
                                break;
                            }
                        case 3:
                            {
                                ProductReaderWriter readerWriter = new ProductReaderWriter();
                                DTOsManager<ProductDTO>.ManageTable(readerWriter);
                                break;
                            }
                    }
                }
            }
        }
    }
}
