using DropdownsAnidados.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DropdownsAnidados.DAO
{
    public class ChoferDAO
    {
        private readonly string cadena = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;


        public List<Chofer> ListarChofers ()
        {
            var listaChofers = new List<Chofer>();

            var conexion = new SqlConnection(cadena);
            conexion.Open();

            var cmd = new SqlCommand("Select cod_chof , nom_chof from Chofer", conexion);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var chofer = new Chofer()
                {
                    CodChofer = reader.GetString(0),
                    NombreChofer = reader.GetString(1)
                };
                listaChofers.Add(chofer);
            }
            conexion.Close();
            reader.Close();

            return listaChofers;
        }



    }
}