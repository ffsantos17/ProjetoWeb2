using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb2;
using ProjetoWeb2.Data;

namespace ProjetoWeb2.Pages.Disciplinas
{
    public class DetailsModel : PageModel
    {
        private readonly ProjetoWeb2.Data.Contexto _context;

        public DetailsModel(ProjetoWeb2.Data.Contexto context)
        {
            _context = context;
        }

      public Disciplina Disciplina { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Disciplina == null)
            {
                return NotFound();
            }

            var disciplina = await _context.Disciplina.FirstOrDefaultAsync(m => m.Id == id);
            if (disciplina == null)
            {
                return NotFound();
            }
            else 
            {
                Disciplina = disciplina;
            }
            return Page();
        }
    }
}
