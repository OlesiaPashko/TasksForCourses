using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class SupplierDTO:IDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProductDTO> ProductDTOs { get; set; }
        public SupplierDTO()
        {
            ProductDTOs = new List<ProductDTO>();
        }

        public override string ToString()
        {
            return $"Supplier Name = {Name}, Supplier Id = {Id}";
        }
    }
}
