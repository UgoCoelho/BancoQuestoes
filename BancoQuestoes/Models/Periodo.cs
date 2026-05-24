namespace BancoQuestoes.Models
{
    public class Periodo
    {
        public int PeriodoId { get; set; }
        public int Numero { get; set; }

        public int CursoId { get; set; }
        public Curso? Curso { get; set; }
    }
}
