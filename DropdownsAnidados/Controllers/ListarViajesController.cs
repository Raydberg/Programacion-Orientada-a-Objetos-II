using DropdownsAnidados.DAO;
using DropdownsAnidados.Models;
using System.Web.Mvc;

namespace DropdownsAnidados.Controllers;

public class ListarViajesController : Controller
{
    // GET: ListarViajes
    private readonly ViajeDAO viajeDao = new();
    private readonly RutaDAO rutaDao = new();
    private readonly ChoferDAO choferDao = new();
    private readonly sp_Listar_Viajes_DAO sp_Listar_Viajes_DAO = new();

    [HttpGet]
    public ActionResult ListarViajesPersonalizado (string cod_rut = null, string cod_chof = null, string hrs_sal = null)
    {
        var viajes = viajeDao.ListarViajes();
        var rutas = rutaDao.ListarRutas();
        var chofers = choferDao.ListarChofers();
        var sp_viajes = sp_Listar_Viajes_DAO.SP_ListarViajes();
        var viewModel = new ViajesRutaViewModel
        {
            Viajes = viajes,
            Rutas = rutas,
            Chofers = chofers,
            ListarViajes = sp_viajes
        };

        return View(viewModel);
    }
}
