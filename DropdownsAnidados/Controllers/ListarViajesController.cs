using DropdownsAnidados.DAO;
using DropdownsAnidados.Models;
using System.Linq;
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
        var sp_viajes = sp_Listar_Viajes_DAO.SP_ListarViajes(cod_rut, cod_chof, hrs_sal);

        var viewModel = new ViajesRutaViewModel
        {
            Viajes = viajes,
            Rutas = rutas,
            Chofers = chofers,
            ListarViajes = sp_viajes
        };

        return View(viewModel);
    }

    [HttpGet]
    public ActionResult EditarViajes (string nroVia)
    {
        var viaje = sp_Listar_Viajes_DAO.SP_ListarViajes().FirstOrDefault(v => v.Nro_Via == nroVia);
        if (viaje == null)
        {
            return HttpNotFound();
        }

        var rutas = rutaDao.ListarRutas();
        var chofers = choferDao.ListarChofers();

        var viewModel = new ViajesRutaViewModel { Viaje = viaje, Rutas = rutas, Chofers = chofers };

        return View(viewModel);
    }

    [HttpPost]
    public ActionResult EditarViajes (ViajesRutaViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            sp_Listar_Viajes_DAO.SP_Editar_Viajes(
                    viewModel.Viaje.Nro_Via,
                    viewModel.Viaje.Cod_Ruta,
                    viewModel.Viaje.Cod_Chofer,
                    viewModel.Viaje.Hora_Salida,
                    viewModel.Viaje.Costo_Via
                );
            return RedirectToAction("ListarViajesPersonalizado");
        }

        viewModel.Rutas = rutaDao.ListarRutas();
        viewModel.Chofers = choferDao.ListarChofers();
        return View(viewModel);
    }

    [HttpGet]
    public ActionResult DetallesViaje (string nroVia)
    {
        var viaje = sp_Listar_Viajes_DAO.SP_ListarViajes().FirstOrDefault(v => v.Nro_Via == nroVia);
        if (viaje == null)
        {
            return HttpNotFound();
        }

        var rutas = rutaDao.ListarRutas();
        var chofers = choferDao.ListarChofers();

        var viewModel = new ViajesRutaViewModel { Viaje = viaje, Rutas = rutas, Chofers = chofers };

        return View(viewModel);
    }

}
