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
    public class IndexModel : PageModel
    {
        private readonly ProjetoWeb2.Data.Contexto _context;

        public IndexModel(ProjetoWeb2.Data.Contexto context)
        {
            _context = context;
        }

        public IList<Disciplina> Disciplina { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Disciplina != null)
            {
                Disciplina = await _context.Disciplina.ToListAsync();
            }
        }
    }
}
