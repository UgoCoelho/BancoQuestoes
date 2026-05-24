using System.ComponentModel.DataAnnotations.Schema;

namespace BancoQuestoes.Models
{
    public class Materia
    {
        public int  MateriaId { get; set; }
        public int Periodo { get; set; }
        public string Nome { get; set; }
        public int CursoId { get; set; }

        [ForeignKey("CursoId")]
        public Curso? Curso { get; set; }

    }
}
