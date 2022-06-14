using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb2;
using ProjetoWeb2.Data;

namespace ProjetoWeb2.Pages.PreRequisitos
{
    public class IndexModel : PageModel
    {
        private readonly ProjetoWeb2.Data.Contexto _context;

        public IndexModel(ProjetoWeb2.Data.Contexto context)
        {
            _context = context;
        }

        public IList<PreRequisito> PreRequisito { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PreRequisito != null)
            {
                PreRequisito = await _context.PreRequisito.ToListAsync();
            }
        }
    }
}
