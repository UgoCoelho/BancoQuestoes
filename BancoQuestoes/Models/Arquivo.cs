namespace BancoQuestoes.Models
{
    public class Arquivo
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Professor { get; set; }

        public string Tag { get; set; }

        public string Descricao { get; set; }

        public Curso CursoId { get; set; }

        public Materia MateriaId { get; set; }

        public TipoArquivo TipoArquivoId { get; set; }

    }
}
