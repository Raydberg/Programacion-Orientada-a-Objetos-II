namespace Transactions_ADO.NET.DAO
{
    public class VendedorDAO
    {
        //public List<FiltroVenta> ListarVendedores ()
        //{
        //    var lista = new List<FiltroVenta>();

        //    using (var cn = DataBaseConnection.ObtenerConexion())
        //    {
        //        cn.Open();
        //        var cmd = new SqlCommand("select cod_ven,nom_ven  from Vendedor");
        //        cmd.CommandType = CommandType.Text;
        //        var reader = cmd.ExecuteReader();


        //        while (reader.Read())
        //        {
        //            var vendedor = new FiltroVenta() { CodVendedor = reader.GetInt32(0), Nombre = reader.GetString(1) };
        //            lista.Add(vendedor);
        //        }

        //        reader.Close();
        //        cn.Close();
        //    }

        //    return lista;
        //}
    }
}
