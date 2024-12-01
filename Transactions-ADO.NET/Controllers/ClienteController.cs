using System;
using System.Linq;
using System.Web.Mvc;
using Transactions_ADO.NET.DAO;
using Transactions_ADO.NET.Models;

namespace Transactions_ADO.NET.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteDAO clienteDAO = new ClienteDAO();
        private readonly DistritoDAO distritoDAO = new DistritoDAO();

        [HttpGet]
        public ActionResult ListarClientes (string eli_cli = "No", int pagina = 0)
        {
            var cantidadTotal = clienteDAO.ListarClientes(eli_cli).Count;
            var cantidadPorPagina = 5;
            var numeroPaginas = (cantidadTotal + cantidadPorPagina - 1) / cantidadPorPagina;

            ViewBag.pagina = pagina;
            ViewBag.numeroPaginas = numeroPaginas;


            var listado = clienteDAO.ListarClientes(eli_cli).Skip(cantidadPorPagina * pagina).Take(cantidadPorPagina);

            return View(listado);
        }

        [HttpGet]
        //Obtener los datos del cliente para grabar
        public ActionResult GrabarClientes ()
        {
            var cliente = new Cliente();

            cliente.fec_nac = new DateTime();
            ViewBag.distritos = new SelectList(distritoDAO.ListadoDistritos(), "cod_dist", "nom_dist");

            return View(cliente);
        }

        [HttpPost]
        public ActionResult GrabarClientes (Cliente cliente)
        {
            var cadena = "";

            try
            {
                //Si el modelo enviado no tiene errores
                if (ModelState.IsValid) cadena = clienteDAO.GrabarCliente(cliente);
            }
            catch (Exception e)
            {
                cadena = "Error al grabar el cliente: " + e.Message;
            }

            ViewBag.mensaje = cadena;
            ViewBag.distritos = new SelectList(distritoDAO.ListadoDistritos(), "cod_dist", "nom_dist");
            return View(cliente);
        }


        public ActionResult DetalleCliente (string id)
        {
            var listado = clienteDAO.ListarClientes("No");

            var cliente = listado.Find(x => x.cod_cli.Equals(id));

            return View(cliente);
        }

        [HttpGet]
        public ActionResult EditarCliente (string id)
        {
            var listado = clienteDAO.ListarClientes("No");

            var cliente = listado.Find(x => x.cod_cli.Equals(id));

            return cliente == null ? View() : View(cliente);
        }

        [HttpPost]
        public ActionResult EditarCliente (Cliente cliente)
        {
            string mensage = string.Empty;

            try
            {
                ViewBag.MENSAJE = ModelState.IsValid ? clienteDAO.ActualizarCliente(cliente) : "ERROR EN LA VALIDACION DE DATOS";
            }
            catch (Exception e)
            {
                ViewBag.MENSAJE = "Error al actualizar el cliente: " + e.Message;
            }

            return View(cliente);
        }

        [HttpGet]
        public ActionResult EliminarCliente (string id)
        {
            var listado = clienteDAO.ListarClientes("No");
            Cliente cliente = listado.Find(x => x.cod_cli.Equals(id));

            return View(cliente);
        }

        [HttpPost]
        public ActionResult EliminarCliente (string id, FormCollection collection)
        {
            ViewBag.MENSAJE = clienteDAO.EliminarCliente(id);
            return View();
        }
    }
}
