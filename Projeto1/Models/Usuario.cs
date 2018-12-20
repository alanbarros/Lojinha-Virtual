using System.ComponentModel.DataAnnotations;

namespace sistemaVendaWebApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }        
        [Required(ErrorMessage="O campo Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage="O campo Nome de usuário é obrigatório"), Display(Name="Nome de usuario")]
        public string Username { get; set; }
        [Required(ErrorMessage="O capo Senha é obrigatório")]
        public string Senha { get; set; }
    }
}