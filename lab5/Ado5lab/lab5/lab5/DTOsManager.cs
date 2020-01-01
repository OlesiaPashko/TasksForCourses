using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
namespace lab5Entity
{
    static class DTOsManager<T> where T : IDTO
    {
        private static IDTO InputElement(T element)
        {
            if (element is ProductDTO)
            {
                Console.WriteLine("Input all information about product");
                Console.WriteLine("Input product name");
                string name = Console.ReadLine();
                Console.WriteLine("Input id of category");
                int categoryId = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Input id of supplier");
                int supplierId = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Input price");
                double price = Double.Parse(Console.ReadLine());
                return new ProductDTO { CategoryId = categoryId, Name = name, SupplierId = supplierId, Price = price };
            }
            else if (element is CategoryDTO)
            {
                Console.WriteLine("Input all information about category");
                Console.WriteLine("Input name");
                string name = Console.ReadLine();
                return new CategoryDTO { Name = name };
            }
            else
            {
                Console.WriteLine("Input all information about supplier");
                Console.WriteLine("Input name");
                string name = Console.ReadLine();
                return new SupplierDTO { Name = name };
            }
        }
        static public void ManageTable(IDataReaderWriter<T> dataReaderWriter)
        {
            Console.WriteLine("press 1 to insert, " +
                    "2 to delete, 3 to get all values of table, 4 to get value by id and 5 to update");
            int chouse = Int32.Parse(Console.ReadLine());
            switch (chouse)
            {
                case 1:
                    {
                        IDTO dto = InputElement(dataReaderWriter.Get(1));
                        dataReaderWriter.Create((T)dto);
                        Console.WriteLine("Element was added");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Please enter id of the element to delete it");
                        int id = Int32.Parse(Console.ReadLine());
                        dataReaderWriter.Delete(id);
                        Console.WriteLine("The element was deleted");
                        break;
                    }
                case 3:
                    {
                        IEnumerable<T> result = dataReaderWriter.GetAll();
                        foreach (var elem in result)
                        {
                            Console.WriteLine(elem);
                        }
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Please enter id of the element to get it");
                        int id = Int32.Parse(Console.ReadLine());
                        T result = dataReaderWriter.Get(id);
                        Console.WriteLine(result);
                        break;
                    }
                case 5:
                    {
                        IDTO dto = InputElement(dataReaderWriter.Get(1));
                        var elem = dataReaderWriter.Get(dto.Id);
                        dataReaderWriter.Update(elem);
                        Console.WriteLine("Element was updated");
                        break;
                    }
            }
        }
    }
}
