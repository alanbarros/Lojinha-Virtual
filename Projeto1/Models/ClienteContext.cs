using Microsoft.EntityFrameworkCore;
using sistemaVendaWebApi.Models;

namespace sistemaVendaWebApi.Models
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options): base(options){}

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<sistemaVendaWebApi.Models.Usuario> Usuario { get; set; }
    }
}