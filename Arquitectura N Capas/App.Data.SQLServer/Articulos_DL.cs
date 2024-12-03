using Entities;
using NCapasADONET.DataAccess;
using System.Collections.Generic;

namespace MainModule
{
    public class Articulos_DL
    {
        public List<Articulos> ListarArticulos ()
        {
            var lista = new List<Articulos>();

            using (var cn = DataBaseConnection.ObtenerConexion())
            {
                var reader = SqlHelper.ExecuteReader(cn, "LISTAR_ARTICULOS");
                Articulos articulo;

                while (reader.Read())
                {
                    articulo = new Articulos()
                    {
                        cod_art = reader.GetString(0)
                        ,
                        nom_art = reader.GetString(1)
                        ,
                        pre_art = reader.GetDecimal(2)
                        ,
                        uni_med = reader.GetString(3)
                        ,
                        stk_art = reader.GetInt32(4)
                    };
                    lista.Add(articulo);
                }

                reader.Close();
            }

            return lista;
        }
    }
}
