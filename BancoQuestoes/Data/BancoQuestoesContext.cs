using Microsoft.EntityFrameworkCore;
using BancoQuestoes.Models;

namespace BancoQuestoes.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Materia> Materias { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TipoArquivo> TipoArquivo { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Arquivo> Arquivo { get; set; }

    }
}

