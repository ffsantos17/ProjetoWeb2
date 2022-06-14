using Microsoft.EntityFrameworkCore;
using ProjetoWeb2;

namespace ProjetoWeb2.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {
        }

        public DbSet<Disciplina>? Disciplina { get; set; }

        public DbSet<ProjetoWeb2.PreRequisito>? PreRequisito { get; set; }
    }
}
