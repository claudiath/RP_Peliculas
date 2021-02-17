using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RP_Peliculas.Data;
using RP_Peliculas.Modelos;

namespace RP_Peliculas.Pages.Peliculas
{
    public class IndexModel : PageModel
    {
        private readonly RP_Peliculas.Data.RP_PeliculasContext _context;

        public IndexModel(RP_Peliculas.Data.RP_PeliculasContext context)
        {
            _context = context;
        }
        public IList<Pelicula> Pelicula { get;set; }
        [BindProperty(SupportsGet = true)]
        public string searchString { get; set; } //variable que se va a utilizar para guardar lo que el usuario ponga en el buscador
        public SelectList genero { get; set; } //lista con generos
        [BindProperty(SupportsGet = true)]
        public string generoPelicula { get; set; } //va ser el valor que elija el usuario al seleccionar un genero de la lista

        public async Task OnGetAsync()
        {
            var pelicula = from n in _context.Pelicula
                           select n;
            if (!string.IsNullOrEmpty(searchString))
            {
                pelicula = pelicula.Where(S => S.Titulo.Contains(searchString));
            }

            IQueryable<string> generoQuery = from m in _context.Pelicula
                                             orderby m.Genero
                                             select m.Genero;
            if (!string.IsNullOrEmpty(generoPelicula))
            {
                pelicula = pelicula.Where(s => s.Genero == generoPelicula);

            }
            genero = new SelectList(await generoQuery.Distinct().ToListAsync());

            Pelicula = await pelicula.ToListAsync(); // para mostrar lo que se filtra en la variable que hemos creado, si no se filtra, se muestra todo
            //Pelicula = await _context.Pelicula.ToListAsync();
        }
    }
}
