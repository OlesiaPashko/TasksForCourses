using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IDTO
    {
        int Id { get; set; }
        string Name { get; set; }
        string ToString();
    }
}
