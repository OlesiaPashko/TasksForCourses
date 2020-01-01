using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public override string ToString()
        {
            return $"Category Name = {Name}, Category Id = {Id}";
        }
    }
}
