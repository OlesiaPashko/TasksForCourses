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
