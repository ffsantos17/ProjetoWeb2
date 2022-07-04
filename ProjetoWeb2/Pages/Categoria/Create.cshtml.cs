using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoWeb2;
using ProjetoWeb2.Data;

namespace ProjetoWeb2.Pages.Categoria
{
    public class CreateModel : PageModel
    {
        private readonly ProjetoWeb2.Data.Contexto _context;

        public CreateModel(ProjetoWeb2.Data.Contexto context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public categoria categoria { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.categoria == null || categoria == null)
            {
                return Page();
            }

            _context.categoria.Add(categoria);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
