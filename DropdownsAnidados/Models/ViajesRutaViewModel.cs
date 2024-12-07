using System.Collections.Generic;

namespace DropdownsAnidados.Models;

public class ViajesRutaViewModel
{
    public List<Viajes> Viajes { get; set; }
    public List<Ruta> Rutas { get; set; }
    public List<sp_ListarViajes> ListarViajes { get; set; }
    public List<Chofer> Chofers { get; set; }
    public sp_ListarViajes Viaje { get; set; }
}
