using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RP_Peliculas.Modelos
{
    public class Pelicula
    {
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }
    public DateTime FechaLanzamiento { get; set; }
    }
}
