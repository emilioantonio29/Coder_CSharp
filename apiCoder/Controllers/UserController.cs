using apiCoder.ADO.NET;
using apiCoder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiCoder.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        [HttpPost]
        public object GetUserController([FromBody] UserLogin user)
        {
            User usuario = new User();
            usuario = UserADO.GetUser(user.NombreUsuario);

            if (usuario.Nombre is null)
            {
                var res = new object[] {
                    new { Unauthorized = "User not found or invalid password"}
};
                return res;
            }
            else {

                if (usuario.Contraseña == user.Contraseña)
                {
                    return usuario;
                }
                else 
                {
                    var res = new object[] {
                    new { Unauthorized = "User not found or invalid password"}
};
                    return res;
                }
            
            }

        }
    }
}
