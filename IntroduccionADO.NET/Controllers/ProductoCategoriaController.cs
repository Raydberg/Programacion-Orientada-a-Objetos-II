using IntroduccionADO.NET.DAO;
using System.Linq;
using System.Web.Mvc;

namespace IntroduccionADO.NET.Controllers
{
    public class ProductoCategoriaController : Controller
    {
        private readonly ProductoCategoriaDAO productoCategoriaDao = new ProductoCategoriaDAO();


        [HttpGet]
        public ActionResult ListarProductoPorCategoria (int pagina = 0)
        {
            var cantidadTotal = productoCategoriaDao.listarProductosCategorias().Count;
            var cantidadPorPagina = 15;

            var numeroPaginas = (cantidadTotal + cantidadPorPagina - 1) / cantidadPorPagina;

            ViewBag.pagina = pagina;
            ViewBag.numeroPaginas = numeroPaginas;


            var listado = productoCategoriaDao.listarProductosCategorias().Skip(cantidadPorPagina * pagina).Take(cantidadPorPagina).ToList();
            return View(listado);
        }
    }
}
