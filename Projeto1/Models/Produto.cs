using System.ComponentModel.DataAnnotations;

namespace sistemaVendaWebApi.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [Display(Name="Descrição")]
        public string Descricao { get; set; }
        [Display(Name="Preço")]
        public double Preco { get; set; }
        public string Marca { get; set; }
        public string Tipo { get; set; }
        public bool Ativo { get; set; }
        public int Garantia { get; set; }

        public Produto(string nome, double preco, string marca, string tipo, bool ativo, int garantia)
        {
            this.Descricao = nome;
            this.Preco = preco;
            this.Marca = marca;
            this.Tipo = tipo;
            this.Ativo = ativo;
            this.Garantia = garantia;
        }

        public Produto() { }

        public override string ToString()
        {
            return Descricao;
        }

        public override bool Equals(object obj)
        {
            var idProd = obj as Produto;

            if(idProd == null)
            {
                return false;
            }

            return Id.Equals(idProd.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}