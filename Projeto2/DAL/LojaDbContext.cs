using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Modelos;

namespace DAL
{
    public class LojaDbContext : DbContext
    {
        public LojaDbContext()
        {
        }

        public LojaDbContext(DbContextOptions<LojaDbContext> options)
            : base(options)
        {
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     if (!optionsBuilder.IsConfigured)
        //     {
        //         optionsBuilder.UseMySql("Server=localhost;User Id=alan;Password=senha123;Database=lojinha");
        //     }
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
