namespace Modelos
{
    public class Item
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
    }
}