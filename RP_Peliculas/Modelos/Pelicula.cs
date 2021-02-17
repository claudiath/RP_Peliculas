using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

    [Column(TypeName = "decimal(18, 2)")] // atributo para añadir decimales
        public decimal Precio { get; set; }

    [DataType(DataType.Date)] //va mostrar solo la fecha en la página web creada

    [Display(Name = "Fecha de Lanzamiento")] // atributo para cambiar el nombre del campo que se le muestra al usuario
        public DateTime FechaLanzamiento { get; set; }
    }
}
