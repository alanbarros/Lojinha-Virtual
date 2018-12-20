using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sistemaVendaWebApi.Models
{
    public class Venda
	{
		public int Id { get; set; }
		public List<Item> Itens { get;  set; }
		public Cliente Cliente { get; set; }
		public DateTime Data { get; set; }
		[Display(Name="Status Venda")]
		public Status StatusVenda { get; set; }

		public Venda() // Molde para venda
		{
			Itens = new List<Item>();
        }

		public Venda(Cliente Cliente, DateTime Data, Status StatusVenda)
		{
			this.Cliente = Cliente;
			this.Data = Data;
			this.StatusVenda = StatusVenda;			
		}

		public Venda (List<Item> itens){ // Criando uma venda sem cliente declarado
            Data = DateTime.Today;
            Itens = itens;
		}

		public Venda(Cliente cliente, List<Item> itens) // Criando uma venda com cliente declarado
        {
			Data = DateTime.Today;
            Itens = itens;
            Cliente = cliente;
        }
        
		public Venda(Venda venda){ // Construtor para editar um avenda pendente
			Itens = venda.Itens;
			StatusVenda = venda.StatusVenda;
		}

		public void AdicionarItem(Item item){
			item.Id = Itens.Count + 1;
			Itens.Add(item);
		}

		public bool DefinirCliente(Cliente cliente){
			try{
				Cliente = cliente;	
			} catch{
				return false;
			}
			return true;
		}

        public double Total()
        {
            double total = 0;

            foreach (var i in Itens)
            {
                total += i.Total();
            }
            return total;
        }

		public override bool Equals(object obj)
		{
			Venda venda = obj as Venda;

			if(venda == null){
				return false;
			}

			return Id.Equals(venda.Id);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		// Fim da classe
	}   
    public enum Status
    {
        Pago, Cancelado, Pendente
    }
}