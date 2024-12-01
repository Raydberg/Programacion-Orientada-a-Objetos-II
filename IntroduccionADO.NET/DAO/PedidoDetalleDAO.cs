using IntroduccionADO.NET.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace IntroduccionADO.NET.DAO
{
    public class PedidoDetalleDAO
    {
        private readonly string cadena = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;

        public List<PedidoDetalle> ListarPedidoDetalle ()
        {
            var conexionSql = new SqlConnection(cadena);
            conexionSql.Open();
            var cmd = new SqlCommand(
                "SELECT p.IdPedido, p.FechaPedido, dp.IdProducto, dp.Cantidad, dp.PrecioUnidad, dp.Descuento\nFROM Pedidos p\nJOIN Detalles_Pedidos dp ON p.IdPedido = dp.IdPedido"
                , conexionSql);
            var reader = cmd.ExecuteReader();

            var lista = new List<PedidoDetalle>();
            PedidoDetalle obj;
            while (reader.Read())
            {
                obj = new PedidoDetalle
                {
                    IdPedido = reader.GetInt32(0)
                    ,
                    FechaPedido = reader.GetDateTime(1)
                    ,
                    IdProducto = reader.GetInt32(2)
                    ,
                    Cantidad = reader.GetInt32(3)
                    ,
                    PrecioUnidad = reader.GetDecimal(4)
                    ,
                    Descuento = reader.GetDecimal(5)
                };
                lista.Add(obj);
            }

            reader.Close();
            conexionSql.Close();

            return lista;
        }
    }
}
