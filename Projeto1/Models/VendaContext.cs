using Microsoft.EntityFrameworkCore;

namespace sistemaVendaWebApi.Models
{
    public class VendaContext : DbContext
    {
        public VendaContext(DbContextOptions<VendaContext> options) : base(options) {}

        public DbSet<Venda> Vendas { get; set; }
    }
}