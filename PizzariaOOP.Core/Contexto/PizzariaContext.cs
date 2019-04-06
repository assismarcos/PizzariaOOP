using System.IO;
using Microsoft.EntityFrameworkCore;
using PizzariaOOP.Core.Dominio;

namespace PizzariaOOP.Core.Contexto
{
    public class PizzariaContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"FileName={Path.Combine(Directory.GetCurrentDirectory(), "PizzariaUDS.db")}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PedidoConfig());
        }
    }
}
