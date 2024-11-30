using IntroduccionADO.NET.DAO;
using System.Web.Mvc;

namespace IntroduccionADO.NET.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteDAO clienteDao = new ClienteDAO();

        // GET: Cliente
        [HttpGet]
        public ActionResult ListadoClientes ()
        {
            var listado = clienteDao.ListarClientes();
            return View(listado);
        }
    }
}
