using apiCoder.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace apiCoder.ADO.NET
{
    public class UserADO
    {
        public static string connectionString = "Data Source=localhost\\SQLEXPRESS;Database=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static User GetUser(string NombreUsuario)
        {
            User user = new User();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Usuario WHERE NombreUsuario = @NombreUsuario", connection))
                {
                    command.Parameters.AddWithValue("@NombreUsuario", NombreUsuario);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user.Id = (object)reader["Id"];
                            user.Nombre = (string)reader["Nombre"];
                            user.Apellido = (string)reader["Apellido"];
                            user.NombreUsuario = (string)reader["NombreUsuario"];
                            user.Contraseña = (string)reader["Contraseña"];
                            user.Mail = (string)reader["Mail"];
                        }
                    }
                }
            }
            return user;
        }

        public static User GetUserById(string id)
        {
            User user = new User();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Usuario WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user.Id = (object)reader["Id"];
                            user.Nombre = (string)reader["Nombre"];
                            user.Apellido = (string)reader["Apellido"];
                            user.NombreUsuario = (string)reader["NombreUsuario"];
                            user.Contraseña = (string)reader["Contraseña"];
                            user.Mail = (string)reader["Mail"];
                        }
                    }
                }
            }
            return user;
        }

        public static List<Producto> GetProductsByUserId(string id)
        {
            List<Producto> items = new List<Producto>();
            Producto product = new Producto();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Producto WHERE IdUsuario = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            product.Id = (object)reader["Id"];
                            product.Descripciones = (string)reader["Descripciones"];
                            product.Costo = (object)reader["Costo"];
                            product.PrecioVenta = (object)reader["PrecioVenta"];
                            product.Stock = (int)reader["Stock"];
                            product.IdUsuario = (object)reader["IdUsuario"];
                            items.Add(product);
                        }
                    }
                }
            }
            return items;
        }

        public static List<ProductoVendido> GetProductsSoldByUserId(string id)
        {

            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
            ProductoVendido vendido = new ProductoVendido();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM ProductoVendido WHERE IdVenta IN (SELECT Id FROM Venta where IdUsuario = @Id)", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vendido.Id = (object)reader["Id"];
                            vendido.Stock = (int)reader["Stock"];
                            vendido.IdProducto = (object)reader["IdProducto"];
                            vendido.IdVenta = (object)reader["IdVenta"];
                            productosVendidos.Add(vendido);
                        }
                    }
                }

            }

            return productosVendidos;
        }

        public static List<Venta> GetSalesByUserId(string id)
        {

            List<Venta> ventas = new List<Venta>();
            Venta venta = new Venta();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Venta WHERE IdUsuario = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            venta.Id = (object)reader["Id"];
                            venta.Comentarios = (string)reader["Comentarios"];
                            venta.IdUsuario = (object)reader["IdUsuario"];
                            ventas.Add(venta);
                        }
                    }
                }

            }

            return ventas;
        }

        public static int UpdateUser(User userObject)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE Usuario set Nombre=@Nombre, Apellido=@Apellido, NombreUsuario=@NombreUsuario, Contraseña=@Contraseña, Mail=@Mail WHERE NombreUsuario =@NombreUsuario", connection))
                {
                    command.Parameters.AddWithValue("@Nombre", userObject.Nombre);
                    command.Parameters.AddWithValue("@Apellido", userObject.Apellido);
                    command.Parameters.AddWithValue("@NombreUsuario", userObject.NombreUsuario);
                    command.Parameters.AddWithValue("@Contraseña", userObject.Contraseña);
                    command.Parameters.AddWithValue("@Mail", userObject.Mail);
               
                    var response = command.ExecuteNonQuery();

                    return response;
                }
            }
        }

        public static int DeleteUser(User userObject)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM Usuario WHERE NombreUsuario=@NombreUsuario", connection))
                {
                    command.Parameters.AddWithValue("@NombreUsuario", userObject.NombreUsuario);

                    var response = command.ExecuteNonQuery();

                    return response;
                }
            }
        }

        public static int CreateUser(User userObject)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO Usuario VALUES(@Nombre, @Apellido, @NombreUsuario, @Contraseña, @Mail)", connection))
                {
                    command.Parameters.AddWithValue("@Nombre", userObject.Nombre);
                    command.Parameters.AddWithValue("@Apellido", userObject.Apellido);
                    command.Parameters.AddWithValue("@NombreUsuario", userObject.NombreUsuario);
                    command.Parameters.AddWithValue("@Contraseña", userObject.Contraseña);
                    command.Parameters.AddWithValue("@Mail", userObject.Mail);

                    var response = command.ExecuteNonQuery();

                    return response;
                }
            }
        }
    }
}
