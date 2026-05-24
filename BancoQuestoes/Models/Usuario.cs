namespace BancoQuestoes.Models
{
    public enum RoleUsuario
    {
        Usuario = 0,
        Admin = 1
    }
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Periodo { get; set; }
        public string Senha { get; set; } = string.Empty;
        public RoleUsuario Role { get; set; } = RoleUsuario.Usuario;
        public int CursoId { get; set; }
        public Curso? Curso { get; set; }
    }
}
// Admin padrão criado na migração:
// 99999999
// Admin@123