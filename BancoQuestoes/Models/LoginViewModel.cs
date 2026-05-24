using System.ComponentModel.DataAnnotations;

namespace BancoQuestoes.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe a matri­cula")]
        [Display(Name = "Matricula")]
        public int Matricula { get; set; }
    }
}