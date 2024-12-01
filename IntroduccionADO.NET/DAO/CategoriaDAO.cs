using IntroduccionADO.NET.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace IntroduccionADO.NET.DAO
{
    public class CategoriaDAO
    {
        private string cadena = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;


        public List<Categoria> ListarCategorias ()
        {
            SqlConnection conexionSql = new SqlConnection(cadena);
            conexionSql.Open();

            SqlCommand cmd = new SqlCommand("Select IdCategoria , NombreCategoria , Descripcion from Categorias", conexionSql);

            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();

            List<Categoria> lista = new List<Categoria>();
            Categoria obj;

            while (reader.Read())
            {
                obj = new Categoria()
                {
                    IdCategoria = reader.GetInt32(0),
                    NombreCategoria = reader.GetString(1),
                    Descripcion = reader.GetString(2)
                };
                lista.Add(obj);
            }
            reader.Close();
            conexionSql.Close();


            return lista;
        }

    }
}