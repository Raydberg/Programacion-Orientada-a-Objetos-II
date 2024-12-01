using IntroduccionADO.NET.DAO;
using System.Web.Mvc;

namespace IntroduccionADO.NET.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriaDAO categoriaDao = new CategoriaDAO();
        // GET: Categoria
        [HttpGet]
        public ActionResult ListarCategorias ()
        {
            var categorias = categoriaDao.ListarCategorias();
            return View(categorias);
        }
    }
}