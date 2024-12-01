using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Transactions_ADO.NET.DataAccess;
using Transactions_ADO.NET.Models;

namespace Transactions_ADO.NET.DAO
{
    public class VentasCabDAO
    {
        public List<VentasCab> ListarVentasCabs (FiltroVenta filtros)
        {
            var lista = new List<VentasCab>();

            using (var cn = DataBaseConnection.ObtenerConexion())
            {
                cn.Open();
                var cmd = new SqlCommand("sp_ObtenerVentasPorVendedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod_ven", filtros.CodVen.HasValue ? (object)filtros.CodVen.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@cod_cli"
                    , string.IsNullOrEmpty(filtros.CodCli) ? (object)DBNull.Value : filtros.CodCli);

                var reader = cmd.ExecuteReader();


                while (reader.Read())
                    lista.Add(new VentasCab()
                    {
                        CodVen = reader.GetInt32(0)
                        ,
                        NomVen = reader.GetString(1)
                        ,
                        CodCli = reader.GetString(2)
                        ,
                        FecVta = reader.GetDateTime(3)
                        ,
                        TotVta = reader.GetDecimal(4)
                    });
            }

            return lista;
        }


        public List<Vendedor> ObtenerVendedores ()
        {
            var lista = new List<Vendedor>();

            using (var cm = DataBaseConnection.ObtenerConexion())
            {
                cm.Open();
                var cmd = new SqlCommand("SELECT cod_ven, nom_ven FROM Vendedor", cm);
                cmd.CommandType = CommandType.Text;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var vendedor = new Vendedor { CodVen = reader.GetInt32(0), NomVen = reader.GetString(1) };
                    lista.Add(vendedor);
                }

                cm.Close();
                reader.Close();
            }

            return lista;
        }

        public List<Cliente> ObtenerClientes ()
        {
            var lista = new List<Cliente>();

            using (var cn = DataBaseConnection.ObtenerConexion())
            {
                cn.Open();
                var cmd = new SqlCommand("SELECT DISTINCT cod_cli FROM Ventas_Cab", cn);

                cmd.CommandType = CommandType.Text;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var cliente = new Cliente { cod_cli = reader.GetString(0) };
                    lista.Add(cliente);
                }
                cn.Close();
                reader.Close();
            }
            return lista;
        }
    }
}
