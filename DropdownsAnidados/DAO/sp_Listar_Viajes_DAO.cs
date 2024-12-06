using DropdownsAnidados.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DropdownsAnidados.DAO;

public class sp_Listar_Viajes_DAO
{
    private readonly string cadena = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;


    public List<sp_ListarViajes> SP_ListarViajes (string cod_rut = null, string cod_chof = null, string hrs_sal = null)
    {
        var listaViajes = new List<sp_ListarViajes>();
        var conexion = new SqlConnection(cadena);
        conexion.Open();
        var cmd = new SqlCommand("ListarViajes", conexion);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@cod_rut", cod_rut);
        cmd.Parameters.AddWithValue("@cod_chof", cod_chof);
        cmd.Parameters.AddWithValue("@hrs_sal", hrs_sal);
        var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            var viaje = new sp_ListarViajes
            {
                Cod_Chofer = reader.GetString(0)
                ,
                Cod_Ruta = reader.GetString(1)
                ,
                Hora_Salida = reader.GetString(2)
                ,
                Destino = reader.GetString(3)
                ,
                Costo_Via = reader.GetDecimal(4)
                ,
                Nombre_Chofer = reader.GetString(5)
                ,
                Nro_Via = reader.GetString(6)
            };
            listaViajes.Add(viaje);
        }

        return listaViajes;
    }
}
