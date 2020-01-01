using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Product
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }

        public override string ToString()
        {
            return $"Name = {Name}, SupplierId = {SupplierId}, CategoryID = {CategoryId}, Price = {Price}";
        }
    }
}
