using IntroduccionADO.NET.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace IntroduccionADO.NET.DAO
{
    public class ProductoCategoriaDAO
    {
        private readonly string cadena = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;

        public List<ProductoCategoria> listarProductosCategorias ()
        {
            var conexionSql = new SqlConnection(cadena);
            conexionSql.Open();
            var cmd = new SqlCommand("pa_productos_por_categoria", conexionSql);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdCategoria", 6);
            var reader = cmd.ExecuteReader();
            List<ProductoCategoria> lista = new List<ProductoCategoria>();
            while (reader.Read())
            {
                ProductoCategoria obj = new ProductoCategoria()
                {
                    IdProducto = reader.GetInt32(0)
                    ,
                    NombreProducto = reader.GetString(1)
                    ,
                    Precio = reader.GetDecimal(2)
                    ,
                    Stock = reader.GetInt16(3)
                    ,
                    NombreProveedor = reader.GetString(4)
                    ,
                    Pais = reader.GetString(5)
                };
                lista.Add(obj);
            }
            reader.Close();
            conexionSql.Close();
            return lista;
        }
    }
}
