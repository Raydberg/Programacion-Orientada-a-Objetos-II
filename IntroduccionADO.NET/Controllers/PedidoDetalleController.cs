using IntroduccionADO.NET.DAO;
using System.Linq;
using System.Web.Mvc;

namespace IntroduccionADO.NET.Controllers
{
    public class PedidoDetalleController : Controller
    {
        private readonly PedidoDetalleDAO pedidoDetalleDao = new PedidoDetalleDAO();

        [HttpGet]
        public ActionResult ListarPedidosDetalles (int pagina = 0)
        {
            var cantidadTotal = pedidoDetalleDao.ListarPedidoDetalle().Count;
            var cantidadPorPagina = 15;
            var numeroPaginas = (cantidadTotal + cantidadPorPagina - 1) / cantidadPorPagina;
            ViewBag.pagina = pagina;
            ViewBag.numeroPaginas = numeroPaginas;
            var listaPedidoDetalles =
                pedidoDetalleDao.ListarPedidoDetalle().Skip(cantidadPorPagina * pagina).Take(cantidadPorPagina);

            return View(listaPedidoDetalles);
        }
    }
}
