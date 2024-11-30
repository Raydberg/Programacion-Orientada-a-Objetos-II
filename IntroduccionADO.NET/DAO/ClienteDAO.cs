using IntroduccionADO.NET.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace IntroduccionADO.NET.DAO
{
    public class ClienteDAO
    {
        //Instanciar la cadena de coneccion
        private string cadena = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;

        public List<Cliente> ListarClientes ()
        {
            //Instanciar la coneccion y abrir la coneccion
            SqlConnection conexionsql = new SqlConnection(cadena);
            conexionsql.Open();

            SqlCommand cmd = new SqlCommand("SELECT IdCliente, NombreCliente, Direccion, Telefono, Pais FROM Clientes", conexionsql);
            /**
             * CommandType.Text: Especifica que la cadena de comando es una instrucción de texto.
             * CommandType.StoredProcedure: Especifica que la cadena de comando es un procedimiento almacenado.
             * CommandType.TableDirect: Especifica que la cadena de comando es una tabla de la base de datos.
             */

            cmd.CommandType = CommandType.Text;
            // Ejecutar el comando SQL y obtener el resultado
            /**
             *SqlDataReader: Proporciona un modo de leer un flujo de filas de una base de datos.
             * SqlDataTables: Representa una tabla de datos en memoria.
             *SqlDataAdapter: Representa un conjunto de comandos de datos y una conexión de base de datos que se utilizan para rellenar un DataSet y actualizar una base de datos de SQL Server.
             */
            SqlDataReader reader = cmd.ExecuteReader();

            List<Cliente> lista = new List<Cliente>();
            Cliente obj;

            while (reader.Read())
            {
                obj = new Cliente()
                {
                    IdCliente = reader.GetString(0),
                    NombreCliente = reader.GetString(1),
                    Direccion = reader.GetString(2),
                    Telefono = reader.GetString(3),
                    Pais = reader.GetString(4)
                };
                lista.Add(obj);
            }
            reader.Close();
            conexionsql.Close();

            return lista;
        }
    }
}
