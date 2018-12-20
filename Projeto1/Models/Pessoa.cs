using System;
using System.ComponentModel.DataAnnotations;

namespace sistemaVendaWebApi.Models
{
    public abstract class Pessoa
    {
        public long ID { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        [Display(Name="Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
		public string Status { get; set; }
		public char Sexo { get; set; }

		public int Idade()
        {
			if (DataNascimento == new DateTime()) return 0;
			var today = DateTime.Today;
			var age = today.Year - DataNascimento.Year;
			if (DataNascimento > today.AddYears(-age)) age--;
			return age;
        }	

		protected Pessoa(string Nome, string Cpf, DateTime DataNascimento, string Status, char Sexo)
        {
            this.Nome = Nome;
            this.Cpf = Cpf;
            this.DataNascimento = DataNascimento;
			this.Status = Status;
			this.Sexo = Sexo;
        }

		protected Pessoa(){}

		protected Pessoa(string Cpf){
			this.Cpf = Cpf;
		}
	}

	public enum StatusEnum{
		Inativo = 0,
        Ativo = 1,
		Bloqueado = 2
	}
}