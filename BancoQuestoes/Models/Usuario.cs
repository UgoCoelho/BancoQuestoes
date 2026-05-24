namespace BancoQuestoes.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        public int Matricula { get; set; }

        public string Nome { get; set; }

        public int CursoId { get; set; }
        public Curso? Curso { get; set; }
    }
}
