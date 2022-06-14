﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb2;
using ProjetoWeb2.Data;

namespace ProjetoWeb2.Pages.PreRequisitos
{
    public class EditModel : PageModel
    {
        private readonly ProjetoWeb2.Data.Contexto _context;

        public EditModel(ProjetoWeb2.Data.Contexto context)
        {
            _context = context;
        }

        [BindProperty]
        public PreRequisito PreRequisito { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PreRequisito == null)
            {
                return NotFound();
            }

            var prerequisito =  await _context.PreRequisito.FirstOrDefaultAsync(m => m.Id == id);
            if (prerequisito == null)
            {
                return NotFound();
            }
            PreRequisito = prerequisito;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PreRequisito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreRequisitoExists(PreRequisito.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PreRequisitoExists(int id)
        {
          return (_context.PreRequisito?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
