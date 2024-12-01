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
            var vendedores = ventasCabDao.ObtenerVendedores();
            var clientes = ventasCabDao.ObtenerClientes();

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

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Filtrar (FiltroVenta filtros)
        {
            var ventas = ventasCabDao.ListarVentasCabs(filtros);
            return PartialView("_ResultadosParciales", ventas);
        }
    }
}
