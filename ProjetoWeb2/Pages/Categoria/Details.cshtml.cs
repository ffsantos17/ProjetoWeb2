using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb2;
using ProjetoWeb2.Data;

namespace ProjetoWeb2.Pages.Categoria
{
    public class DetailsModel : PageModel
    {
        private readonly ProjetoWeb2.Data.Contexto _context;

        public DetailsModel(ProjetoWeb2.Data.Contexto context)
        {
            _context = context;
        }

      public categoria categoria { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.categoria == null)
            {
                return NotFound();
            }

            var categoria = await _context.categoria.FirstOrDefaultAsync(m => m.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }
            else 
            {
                categoria = categoria;
            }
            return Page();
        }
    }
}
