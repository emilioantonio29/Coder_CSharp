using apiCoder.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace apiCoder.ADO.NET
{
    public class ProductADO
    {
        public static string connectionString = "Data Source=localhost\\SQLEXPRESS;Database=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static Producto GetProduct(string id)
        {
            Producto producto = new Producto();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Producto WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            producto.Id = (object)reader["Id"];
                            producto.Descripciones = (string)reader["Descripciones"];
                            producto.Costo = (object)reader["Costo"];
                            producto.PrecioVenta = (object)reader["PrecioVenta"];
                            producto.Stock = (int)reader["Stock"];
                            producto.IdUsuario = (object)reader["IdUsuario"];
                        }
                    }
                }
            }
            return producto;
        }

        public static int CreateProduct(CreateProducto producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO Producto VALUES (@Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario)", connection))
                {
                    command.Parameters.AddWithValue("@Descripciones", producto.Descripciones);
                    command.Parameters.AddWithValue("@Costo", producto.Costo);
                    command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    command.Parameters.AddWithValue("@Stock", producto.Stock);
                    command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);
               
                    var response = command.ExecuteNonQuery();

                    return response;
                }
            }
        }

        public static int UpdateProduct(CreateProducto producto)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE Producto set Descripciones=@Descripciones, Costo=@Costo, PrecioVenta=@PrecioVenta, Stock=@Stock, IdUsuario=@IdUsuario WHERE Id =@Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", producto.Id);
                    command.Parameters.AddWithValue("@Descripciones", producto.Descripciones);
                    command.Parameters.AddWithValue("@Costo", producto.Costo);
                    command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    command.Parameters.AddWithValue("@Stock", producto.Stock);
                    command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);

                    var response = command.ExecuteNonQuery();

                    return response;
                }
            }
        }

        public static int DeleteProductByUserId(int IdUsuario)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM Producto WHERE IdUsuario=@IdUsuario", connection))
                {
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    var response = command.ExecuteNonQuery();

                    return response;
                }
            }
        }

        public static int DeleteProductByProductId(int Id)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM Producto WHERE Id=@Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    var response = command.ExecuteNonQuery();

                    return response;
                }
            }
        }
    }
}
