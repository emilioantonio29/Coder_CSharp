using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiCoder.Models
{
    public class ProductoVendido
    {
        public object Id { get; set; }
        public int Stock { get; set; }
        public object IdProducto { get; set; }
        public object IdVenta { get; set; }

    }
}
