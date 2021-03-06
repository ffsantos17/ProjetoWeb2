using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb2;
using ProjetoWeb2.Data;

namespace ProjetoWeb2.Pages.Disciplinas
{
    public class CreateModel : PageModel
    {
        private readonly ProjetoWeb2.Data.Contexto _context;

        public CreateModel(ProjetoWeb2.Data.Contexto context)
        {
            _context = context;
        }
        public IList<categoria> vListCategoria { get; set; } = default!;

        public IActionResult OnGet()
        {
            
            return Page();
        }

        [BindProperty]
        public Disciplina Disciplina { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.categoria != null)
            {
                vListCategoria = await _context.categoria.ToListAsync();
            }
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid || _context.Disciplina == null || Disciplina == null)
            {
                return Page();
            }

            _context.Disciplina.Add(Disciplina);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
