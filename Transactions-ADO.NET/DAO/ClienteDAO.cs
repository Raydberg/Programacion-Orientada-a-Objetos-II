using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Transactions_ADO.NET.Models;

namespace Transactions_ADO.NET.DAO
{
    public class ClienteDAO
    {
        private string cadena = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;


        public List<Cliente> ListarClientes (string eli_cli)
        {
            var lista = new List<Cliente>();
            var cn = new SqlConnection(cadena);
            cn.Open();

            var cmd = new SqlCommand("PA_LISTAR_CLIENTES", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eli_cli", eli_cli);
            var reader = cmd.ExecuteReader();
            Cliente cliente;

            while (reader.Read())
            {
                cliente = new Cliente()
                {
                    cod_cli = reader.GetString(0)
                    ,
                    nom_cli = reader.GetString(1)
                    ,
                    tel_cli = reader.GetString(2)
                    ,
                    cor_cli = reader.GetString(3)
                    ,
                    dir_cli = reader.GetString(4)
                    ,
                    cred_cli = reader.GetInt32(5)
                    ,
                    fec_nac = reader.GetDateTime(6)
                    ,
                    cod_dist = reader.GetInt32(7)
                };
                lista.Add(cliente);
            }

            cn.Close();
            reader.Close();
            return lista;
        }


        public string GrabarCliente (Cliente cliente)
        {
            //Guardara un mensaje de alerta
            var mensaje = "";
            var cn = new SqlConnection(cadena);
            try
            {
                cn.Open();
                var cmd = new SqlCommand("PA_INSERTAR_CLIENTE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod_cli", cliente.cod_cli);
                cmd.Parameters.AddWithValue("@nom_cli", cliente.nom_cli);
                cmd.Parameters.AddWithValue("@tel_cli", cliente.tel_cli);
                cmd.Parameters.AddWithValue("@cor_cli", cliente.cor_cli);
                cmd.Parameters.AddWithValue("@dir_cli", cliente.dir_cli);
                cmd.Parameters.AddWithValue("@cred_cli", cliente.cred_cli);
                cmd.Parameters.AddWithValue("@fec_nac", cliente.fec_nac);
                cmd.Parameters.AddWithValue("@cod_dist", cliente.cod_dist);

                cmd.ExecuteNonQuery();
                mensaje = "Nuevo cliente  : " + cliente.nom_cli + "grabado correctamente";
            }
            catch (Exception ex)
            {
                mensaje = "ERROR : " + ex.Message;
            }
            finally
            {
                cn.Close();
            }

            return mensaje;
        }

        public string ActualizarCliente (Cliente cliente)
        {
            var mensaje = "";
            var cn = new SqlConnection(cadena);
            try
            {
                cn.Open();
                var cmd = new SqlCommand("PA_ACTUALIZAR_CLIENTE", cn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cod_cli", cliente.cod_cli);
                cmd.Parameters.AddWithValue("@nom_cli", cliente.nom_cli);
                cmd.Parameters.AddWithValue("@tel_cli", cliente.tel_cli);
                cmd.Parameters.AddWithValue("@cor_cli", cliente.cor_cli);
                cmd.Parameters.AddWithValue("@dir_cli", cliente.dir_cli);
                cmd.Parameters.AddWithValue("@cred_cli", cliente.cred_cli);
                cmd.Parameters.AddWithValue("@fec_nac", cliente.fec_nac);
                cmd.Parameters.AddWithValue("@cod_dist", cliente.cod_dist);
                cmd.ExecuteNonQuery();
                mensaje = "Cliente : " + cliente.nom_cli + " actualizado correctamente";
            }
            catch (Exception ex)
            {
                mensaje = "ERROR : " + ex.Message;
            }
            finally
            {
                cn.Close();
            }

            return mensaje;
        }

        public string EliminarCliente (string cod_cliente)
        {
            var mensaje = "";
            var cn = new SqlConnection(cadena);

            try
            {
                cn.Open();
                var cmd = new SqlCommand("PA_ELIMINAR_CLIENTE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod_cli", cod_cliente);
                cmd.ExecuteNonQuery();
                mensaje = "Cliente de codigo  : " + cod_cliente + " eliminado correctamente";
            }
            catch (Exception ex)
            {
                mensaje = "ERROR : " + ex.Message;
            }
            finally
            {
                cn.Close();
            }


            return mensaje;
        }
    }
}
