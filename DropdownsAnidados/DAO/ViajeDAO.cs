using DropdownsAnidados.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace DropdownsAnidados.DAO;

public class ViajeDAO
{
    private readonly string cadena = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;

    public List<Viajes> ListarViajes ()
    {
        var conexionSQL = new SqlConnection(cadena);
        conexionSQL.Open();

        var cmd = new SqlCommand("SELECT hrs_sal FROM Viajes", conexionSQL);

        var reader = cmd.ExecuteReader();

        var lista = new List<Viajes>();

        while (reader.Read())
        {
            var viaje = new Viajes { Hora_Salida = reader.GetString(0) };
            lista.Add(viaje);
        }

        reader.Close();
        conexionSQL.Close();

        return lista.GroupBy(v => v.Hora_Salida).Select(g => g.First()).ToList();
    }
}
