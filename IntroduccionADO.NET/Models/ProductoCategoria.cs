namespace IntroduccionADO.NET.Models
{
    public class ProductoCategoria
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string NombreProveedor { get; set; }
        public string Pais { get; set; }
    }
}
