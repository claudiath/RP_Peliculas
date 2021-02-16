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
    public class DetailsModel : PageModel
    {
        private readonly RP_Peliculas.Data.RP_PeliculasContext _context;

        public DetailsModel(RP_Peliculas.Data.RP_PeliculasContext context)
        {
            _context = context;
        }

        public Pelicula Pelicula { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pelicula = await _context.Pelicula.FirstOrDefaultAsync(m => m.Id == id);

            if (Pelicula == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
