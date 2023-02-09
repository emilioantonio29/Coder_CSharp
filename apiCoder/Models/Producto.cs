using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiCoder.Models
{
    public class Producto
    {
        public object Id { get; set; }
        public string Descripciones { get; set; }
        public object Costo { get; set; }
        public object PrecioVenta { get; set; }
        public int Stock { get; set; }
        public object IdUsuario { get; set; }
    }

    public class CreateProducto
    {
        public int Id { get; set; }
        public string Descripciones { get; set; }
        public System.Decimal Costo { get; set; }
        public System.Decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }
    }
}
