﻿using apiCoder.ADO.NET;
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
        [Route("getUser")]
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
                return res[0];
            }
            else {

                if (usuario.Contraseña == user.Contraseña)
                {
                    return usuario;
                }
                else 
                {
                    var res = new object[] {new { Unauthorized = "User not found or invalid password"}};
                    return res[0];
                }
            
            }

        }

        [Route("getUserById/{userId}")]
        [HttpGet]
        public object GetUserByIdController([FromRoute] string userId)
        {
            User usuario = new User();
            usuario = UserADO.GetUserById(userId);

            if (usuario.Nombre is null)
            {
                var res = new object[] {
                    new { NotFound = "User not found"}
};
                return res[0];
            }
            else
            {

                return usuario;

            }

        }

        [Route("getProductsByUserId/{userId}")]
        [HttpGet]
        public object GetProductsByUserIdController([FromRoute] string userId)
        {
            List<Producto> items = new List<Producto>();
            items = UserADO.GetProductsByUserId(userId);

            if (items.Count > 0)
            {
                return items;
            }
            else
            {

                var res = new object[] {new { ProductsNotFound = "There's no products added by that user"}};
                return res[0];

            }

        }

        [Route("getProductsSoldByUserId/{userId}")]
        [HttpGet]
        public object GetProductsSoldByUserIdController([FromRoute] string userId)
        {
            List<ProductoVendido> items = new List<ProductoVendido>();
            items = UserADO.GetProductsSoldByUserId(userId);

            if (items.Count > 0)
            {
                return items;
            }
            else
            {

                var res = new object[] { new { ProductsNotFound = "There's no products sold by that user" } };
                return res[0];

            }

        }

        [Route("getSalesByUserId/{userId}")]
        [HttpGet]
        public object GetSalesByUserIdController([FromRoute] string userId)
        {
            List<Venta> items = new List<Venta>();
            items = UserADO.GetSalesByUserId(userId);

            if (items.Count > 0)
            {
                return items;
            }
            else
            {

                var res = new object[] { new { SalesNotFound = "User has no sales" } };
                return res[0];

            }

        }
    }
}
