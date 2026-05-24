namespace BancoQuestoes.Models
{
    public class Arquivo
    {
        public int Id { get; set; }

        public string? Titulo { get; set; }

        public string? Professor { get; set; }

        public string? Tag { get; set; }

        public string? Descricao { get; set; }

        public int CursoId { get; set; }
        public Curso? Curso { get; set; }
        
        public int MateriaId { get; set; }
        public Materia? Materia { get; set; }

        public int TipoArquivoId { get; set; }
        public TipoArquivo? TipoArquivo { get; set; }

    }
}
