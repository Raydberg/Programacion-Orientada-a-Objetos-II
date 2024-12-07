using DropdownsAnidados.Models;
using System;
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
        cmd.Parameters.AddWithValue("@cod_rut", (object)cod_rut ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@cod_chof", (object)cod_chof ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@hrs_sal", (object)hrs_sal ?? DBNull.Value);
        var reader = cmd.ExecuteReader();

        try
        {
            while (reader.Read())
            {
                var viaje = new sp_ListarViajes
                {
                    Cod_Ruta = reader.GetString(0)
                    ,
                    Cod_Chofer = reader.GetString(1)
                    ,
                    Nombre_Chofer = reader.GetString(2)
                    ,
                    Destino = reader.GetString(3)
                    ,
                    Hora_Salida = reader.GetString(4)
                    ,
                    Costo_Via = reader.GetDecimal(5)
                    ,
                    Nro_Via = reader.GetString(6)
                };
                listaViajes.Add(viaje);
            }
        }
        catch (ConfigurationErrorsException e)
        {
            Console.WriteLine("Error al traer los datos " + e);
        }
        finally
        {
            reader.Close();
            conexion.Close();
        }

        return listaViajes;
    }


    public void SP_Editar_Viajes (string nroVia, string? codRut, string? codChof, string hrsSal, decimal? costoVia)
    {
        var conexionSql = new SqlConnection(cadena);
        conexionSql.Open();
        var cmd = new SqlCommand("ActualizarViaje", conexionSql);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@nro_via", nroVia);
        cmd.Parameters.AddWithValue("@cod_rut", (object)codRut ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@cod_chof", (object)codChof ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@hrs_sal", (object)hrsSal ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@costo_via", (object)costoVia ?? DBNull.Value);
        cmd.ExecuteNonQuery();
        conexionSql.Close();
    }


    public void SP_Detalles_Viaje (string nroVia, string? codRut, string? codChof, string hrsSal, decimal? costoVia)
    {
        var conexionSql = new SqlConnection(cadena);
        conexionSql.Open();
        var cmd = new SqlCommand("ActualizarViaje", conexionSql);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@nro_via", nroVia);
        cmd.Parameters.AddWithValue("@cod_rut", (object)codRut ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@cod_chof", (object)codChof ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@hrs_sal", (object)hrsSal ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@costo_via", (object)costoVia ?? DBNull.Value);
        cmd.ExecuteNonQuery();
        conexionSql.Close();
    }


    public void SP_Eliminar_Viaje (string nroVia)
    {
        var conexionSql = new SqlConnection(cadena);
        conexionSql.Open();

        var cmd = new SqlCommand("EliminarViaje", conexionSql);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@nro_via", nroVia);
        cmd.ExecuteNonQuery();
        conexionSql.Close();
    }



}
