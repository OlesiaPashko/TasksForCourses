using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int? SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
