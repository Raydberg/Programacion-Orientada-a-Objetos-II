using IntroduccionADO.NET.DAO;
using System.Linq;
using System.Web.Mvc;

namespace IntroduccionADO.NET.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteDAO clienteDao = new ClienteDAO();

        // GET: Cliente
        [HttpGet]
        public ActionResult ListadoClientes (int pagina = 0)
        {
            var cantidadTotal = clienteDao.ListarClientes().Count();
            var cantidadPorPagina = 15;
            var numeroPaginas = (cantidadTotal + cantidadPorPagina - 1) / cantidadPorPagina;

            ViewBag.pagina = pagina;
            ViewBag.numeroPaginas = numeroPaginas;

            var clientes = clienteDao.ListarClientes().Skip(cantidadPorPagina * pagina).Take(cantidadPorPagina).ToList();

            return View(clientes);
        }


    }
}
