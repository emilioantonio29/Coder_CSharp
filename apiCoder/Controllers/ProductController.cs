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
    public class ProductController : ControllerBase
    {
        [Route("createProduct")]
        [HttpPost]
        public object CreateProductController([FromBody] CreateProducto producto)
        {

            CreateProducto newProduct = new CreateProducto();

            var result = ProductADO.CreateProduct(producto);

            if (result > 0)
            {
                var res = new object[] {new { CreatedSuccessfully = "Product created successfully"}};
                return res[0];
            }
            else
            {
                var res = new object[] { new { Error = "Unable to create producto, please try again" } };
                return res[0];
            }

        }

        [Route("updateProduct")]
        [HttpPut]
        public object UpdateProductController([FromBody] CreateProducto producto)
        {

            Producto newProduct = new Producto();
            newProduct = ProductADO.GetProduct(producto.Id.ToString());

            if (newProduct.Id is null)
            {
                var res = new object[] { new { ProductNotFound = "Unable to update. Product not found." } };
                return res[0];
            }
            else
            {

                int result = ProductADO.UpdateProduct(producto);

                if (result > 0)
                {
                    var res = new object[] { new { ProductUpdated = "Product updated successfully." } };
                    return res[0];
                }
                else 
                {
                    var res = new object[] { new { Error = "Unable to update. Please try again in a few minutes." } };
                    return res[0];
                }

            }

        }
    }
}
