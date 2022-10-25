using ApiCarros.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace ApiCarros.Data
{
    public class EstoqueContext : DbContext
    {
        public EstoqueContext(DbContextOptions<EstoqueContext> options) : base(options)
        {

        }


        public DbSet<Carro> Carros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carro>().HasKey(p => p.Id);
            modelBuilder.Entity<Carro>().Property(p => p.Ano).IsRequired();
            modelBuilder.Entity<Carro>().Property(p => p.Marca).IsRequired();
            modelBuilder.Entity<Carro>().Property(p => p.Quantidade).IsRequired();
            modelBuilder.Entity<Carro>().Property(p => p.Modelo).IsRequired();
            modelBuilder.Entity<Carro>().Property(p => p.Valor).IsRequired();

        }


    }
}
