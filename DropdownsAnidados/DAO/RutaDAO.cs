using DropdownsAnidados.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DropdownsAnidados.DAO;

public class RutaDAO
{
    private readonly string cadena = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;

    public List<Ruta> ListarRutas ()
    {
        var listaRutas = new List<Ruta>();

        var conexion = new SqlConnection(cadena);
        conexion.Open();

        var cmd = new SqlCommand("select cod_rut, des_rut from Rutas", conexion);
        cmd.CommandType = CommandType.Text;
        var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            var ruta = new Ruta { CodRuta = reader.GetString(0), Destino = reader.GetString(1) };
            listaRutas.Add(ruta);
        }

        reader.Close();
        conexion.Close();
        return listaRutas;
    }
}
