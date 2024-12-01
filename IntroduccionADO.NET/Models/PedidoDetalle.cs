using System;

namespace IntroduccionADO.NET.Models
{
    public class PedidoDetalle
    {
        public int IdPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnidad { get; set; }
        public decimal Descuento { get; set; }
    }
}
