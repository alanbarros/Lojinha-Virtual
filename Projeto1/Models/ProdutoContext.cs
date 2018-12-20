using Microsoft.EntityFrameworkCore;

namespace sistemaVendaWebApi.Models
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options){}
        public DbSet<Produto> Produtos { get; set; }
    }
}