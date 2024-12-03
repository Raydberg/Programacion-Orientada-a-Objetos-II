using System.Configuration;
using System.Data.SqlClient;

namespace NCapasADONET.DataAccess
{
    public class DataBaseConnection
    {
        private static readonly string cadena = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;

        public static SqlConnection ObtenerConexion () { return new SqlConnection(cadena); }
    }
}
