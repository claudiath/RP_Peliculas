using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public async Task OnGetAsync()
        {
            Pelicula = await _context.Pelicula.ToListAsync();
        }
    }
}
