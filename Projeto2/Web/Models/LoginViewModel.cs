using System.ComponentModel.DataAnnotations;
using Modelos;

namespace Web.Models
{
    public class LoginViewModel : Usuario
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Repita a Senha")]
        [Compare("Password",ErrorMessage = "As senhas não são iguais")]
        public string PasswordRepeat { get; set; } 
    }
}