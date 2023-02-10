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
                var res = new object[] { new { Error = "Unable to create product, please try again" } };
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

        [Route("getUserById/{productId}")]
        [HttpDelete]
        public object DeleteProductController([FromRoute] int productId)
        {

            Producto newProduct = new Producto();
            newProduct = ProductADO.GetProduct(productId.ToString());

            if (newProduct.Id is null)
            {
                var res = new object[] { new { ProductNotFound = "Unable to delete. Product not found" } };
                return res[0];
            }
            else 
            {
                var result = ProductADO.DeleteProductByProductId(productId);

                if (result > 0)
                {
                    var res = new object[] { new { ProductDeletedSuccessfully = "Product deleted successfully" } };
                    return res[0];
                }
                else
                {
                    var res = new object[] { new { Error = "Unable to delete product, please try again" } };
                    return res[0];
                }
            }

        }

        [Route("getAllProducts")]
        [HttpGet]
        public object GetAllProductsController()
        {
            List<Producto> items = new List<Producto>();
            items = ProductADO.GetAllProducts();

            if (items.Count > 0)
            {
                return items;
            }
            else
            {

                var res = new object[] { new { ProductsNotFound = "There's no products" } };
                return res[0];

            }

        }

        [Route("getAllSoldProducts")]
        [HttpGet]
        public object GetAllSoldProductsController()
        {
            List<ProductoVendido> items = new List<ProductoVendido>();
            items = ProductADO.GetAllSoldProducts();

            if (items.Count > 0)
            {
                return items;
            }
            else
            {

                var res = new object[] { new { SoldProductsNotFound = "Unable to response. There's no sold products yet" } };
                return res[0];

            }

        }

        [Route("getSales")]
        [HttpGet]
        public object GetAllSalesController()
        {
            List<Venta> items = new List<Venta>();
            items = ProductADO.GetAllSales();

            if (items.Count > 0)
            {
                return items;
            }
            else
            {

                var res = new object[] { new { SalesNotFound = "Unable to response. There's no sales yet" } };
                return res[0];

            }

        }
    }
}
