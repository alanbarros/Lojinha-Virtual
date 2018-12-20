using System;

namespace sistemaVendaWebApi.Models
{
    public class Cliente : Pessoa
    {
        public Cliente(string Nome, string Cpf, DateTime DataNascimento, string Status, char Sexo) : base(Nome, Cpf, DataNascimento, Status, Sexo) { }

		public Cliente(string Cpf) : base(Cpf){}

		public Cliente(){}

        public override string ToString()
        {
            return Nome;
        }        

		public override bool Equals(object obj)
		{
			var idCli = obj as Cliente;

			if (idCli == null){
				return false;
			}

			return Cpf.Equals(idCli.Cpf);
		}

		public override int GetHashCode()
		{
			return Cpf.GetHashCode();
		}
    }
}