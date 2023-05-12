using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAula.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Valor { get; set; }

    }

    public static List<Producto> Todos()
    {
        List<Producto> producto = new List<Producto>();
        /* SQL Server (SqlConnection connection = new SqlConnection(connectionString)) */
        using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString)) /* Postgresql */

        {
            string query = "SELECT Id, Nome, Valor FROM Productos";
            NpgsqlCommand command = new NpgsqlCommand( query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Producto producto = new Producto
                {
                    Id = (int)reader["Id"],
                    Nome = reader["Nome"].ToString(),
                    Valor = reader["Valor"].ToString()
                };

                if (reader["id_producto"] != DBNull.Value)
                    cliente.Valor = new Cidade() { Id = Convert.ToInt32(reader["id_cidade"]) };

                productos.Add(producto);
            }
        }
        return productos;
    }

}