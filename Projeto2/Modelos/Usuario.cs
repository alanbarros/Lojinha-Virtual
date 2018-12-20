using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name="Nome de Usuário")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Senha")]
        public string Password { get; set; }

        public override bool Equals(object obj)
        {
            var u = obj as Usuario;

            if (u == null)
            {
                return false;
            }

            return u.Username.Equals(this.Username) && u.Password.Equals(this.Password);
        }
        
        // override object.GetHashCode
        public override int GetHashCode()
        {
            var code = string.Concat(this.Username,this.Password);

            return code.GetHashCode();
        }

    }    
}