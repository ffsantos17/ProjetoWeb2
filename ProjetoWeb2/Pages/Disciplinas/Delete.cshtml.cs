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
    public class DeleteModel : PageModel
    {
        private readonly ProjetoWeb2.Data.Contexto _context;

        public DeleteModel(ProjetoWeb2.Data.Contexto context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Disciplina == null)
            {
                return NotFound();
            }
            var disciplina = await _context.Disciplina.FindAsync(id);

            if (disciplina != null)
            {
                Disciplina = disciplina;
                _context.Disciplina.Remove(Disciplina);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
