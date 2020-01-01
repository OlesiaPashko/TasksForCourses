using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class ProductDTO:IDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int? SupplierId { get; set; }
        public virtual SupplierDTO SupplierDTO { get; set; }

        public int? CategoryId { get; set; }
        public virtual CategoryDTO CategoryDTO { get; set; }

        public override string ToString()
        {
            return $"Name = {Name}, SupplierId = {SupplierId}, CategoryID = {CategoryId}, Price = {Price}";
        }
    }
}
