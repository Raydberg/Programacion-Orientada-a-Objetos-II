using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Transactions_ADO.NET.DataAccess;
using Transactions_ADO.NET.Models;

namespace Transactions_ADO.NET.DAO
{
    public class DistritoDAO
    {
        public List<Distrito> ListadoDistritos ()
        {
            var lista = new List<Distrito>();

            using (var cn = DataBaseConnection.ObtenerConexion())
            {
                cn.Open();
                var cmd = new SqlCommand("SELECT * FROM Distritos", cn);

                cmd.CommandType = CommandType.Text;

                var reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    var distrito = new Distrito { cod_dist = reader.GetInt32(0), nom_dist = reader.GetString(1) };
                    lista.Add(distrito);
                }

                reader.Close();
                cn.Close();
            }


            return lista;
        }
    }
}
