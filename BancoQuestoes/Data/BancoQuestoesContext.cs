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

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<Materia> Materias { get; set; }
    }
}