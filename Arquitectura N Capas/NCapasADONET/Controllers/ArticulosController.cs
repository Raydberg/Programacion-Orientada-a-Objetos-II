using MainModule;
using System.Web.Mvc;

namespace NCapasADONET.Controllers
{
    public class ArticulosController : Controller
    {

        ArticulosManager manager = new ArticulosManager();

        // GET: Articulos
        public ActionResult ListarArticulos ()
        {
            var lista = manager.Listar_Articulos();
            return View(lista);
        }
    }
}