using Entities;
using System.Collections.Generic;

namespace MainModule
{
    public class ArticulosManager
    {
        private Articulos_DL dao = new Articulos_DL();

        public List<Articulos> Listar_Articulos () { return dao.ListarArticulos(); }
    }
}
