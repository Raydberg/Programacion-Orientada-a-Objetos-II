using System;

namespace Transactions_ADO.NET.Models
{
    public class VentasCab
    {
        public int CodVen { get; set; }
        public string NomVen { get; set; }
        public string CodCli { get; set; }
        public DateTime FecVta { get; set; }
        public decimal TotVta { get; set; }
    }
}
