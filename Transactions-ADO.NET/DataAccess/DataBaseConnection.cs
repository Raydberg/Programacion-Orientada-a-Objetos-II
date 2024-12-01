using System.Configuration;

namespace Transactions_ADO.NET.DataAccess
{
    public class DataBaseConnection
    {
        private static readonly string cadena = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;

        public static System.Data.SqlClient.SqlConnection ObtenerConexion () { return new System.Data.SqlClient.SqlConnection(cadena); }
    }
}
