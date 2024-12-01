using System.Linq;
using System.Web.Mvc;
using Transactions_ADO.NET.DAO;
using Transactions_ADO.NET.Models;

namespace Transactions_ADO.NET.Controllers
{
    public class VentasCabController : Controller
    {
        private readonly VentasCabDAO ventasCabDao = new VentasCabDAO();

        [HttpGet]
        public ActionResult ObtenerVentas ()
        {
            // Obtener listas de vendedores y clientes para los selects
            var vendedores = ventasCabDao.ObtenerVendedores();
            var clientes = ventasCabDao.ObtenerClientes();

            // Crear el ViewModel para la vista
            var viewModel = new FiltroVentaViewModel
            {
                Vendedores = vendedores.Select(v => new SelectListItem
                {
                    Value = v.CodVen.ToString(),
                    Text = v.NomVen
                }).ToList(),
                Clientes = clientes.Select(c => new SelectListItem
                {
                    Value = c.cod_cli,
                    Text = c.cod_cli
                }).ToList()
            };

            return View(viewModel); // Vista principal
        }

        [HttpPost]
        public ActionResult Filtrar (FiltroVenta filtros)
        {
            // Obtener las ventas filtradas
            var ventas = ventasCabDao.ListarVentasCabs(filtros);

            // Devolver resultados como una vista parcial
            return PartialView("_ResultadosParciales", ventas);
        }
    }
}
