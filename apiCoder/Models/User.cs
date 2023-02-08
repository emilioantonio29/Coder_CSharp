using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace apiCoder.Models
{
    public class User
    {
        public object Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Mail { get; set; }
    }

    public class UserLogin
    {
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
    }
}
