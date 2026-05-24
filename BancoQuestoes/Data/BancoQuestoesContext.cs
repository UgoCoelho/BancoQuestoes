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
        public DbSet<BancoQuestoes.Models.Usuario> Usuario { get; set; } = default!;
        public DbSet<BancoQuestoes.Models.TipoArquivo> TipoArquivo { get; set; } = default!;
        public DbSet<BancoQuestoes.Models.Curso> Curso { get; set; } = default!;
        public DbSet<BancoQuestoes.Models.Arquivo> Arquivo { get; set; } = default!;
    }
}