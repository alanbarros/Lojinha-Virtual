using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required, Display(Name="Descrição")]
        public string Descricao { get; set; }
        [Required, Display(Name="Preço")]
        public decimal Preco { get; set; }
        [Required, Display(Name="Quantidade em Estoque")]
        public double QuantidadeEstoque { get; set; }
    }
}