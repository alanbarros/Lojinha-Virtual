namespace sistemaVendaWebApi.Models
{
    public class Item
    {
		public int Id { get; set; }
		public Produto Produto { get; set; }
		public int Quantidade { get; set; }

        public Item() { }

        public Item(Produto p, int qtd)
        {
            Produto = p;
            Quantidade = qtd;
            if (Quantidade > 0) Total(); // Fazer tratativa caso a quantidade for igual ou menor que zero.
		}
        
        public double Total()
        {
            return Produto.Preco * Quantidade;
        }
    }
}