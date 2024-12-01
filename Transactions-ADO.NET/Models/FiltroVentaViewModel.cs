using System.Collections.Generic;
using System.Web.Mvc;

namespace Transactions_ADO.NET.Models
{
    public class FiltroVentaViewModel
    {
        public int? CodVen { get; set; }
        public string CodCli { get; set; }
        public List<SelectListItem> Vendedores { get; set; }
        public List<SelectListItem> Clientes { get; set; }
    }
}