namespace BancoQuestoes.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        public int Matricula { get; set; }

        public string Nome { get; set; } = string.Empty;
        public int Periodo { get; set; }
        public string Senha { get; set; } = string.Empty;

        public int CursoId { get; set; }
        public Curso? Curso { get; set; }
    }
}
