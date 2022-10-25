using ApiCarros.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiCarros.Data
{
    public class VendasContext : DbContext
    {

        public VendasContext(DbContextOptions<VendasContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<CarroVendido> CarrosVendidos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>().HasKey(p => p.Id);
            modelBuilder.Entity<CarroVendido>().HasKey(p => p.Id);



            modelBuilder.Entity<Cliente>()
                .HasIndex(p => p.Cpf)
                .IsUnique();
            modelBuilder.Entity<CarroVendido>()
                .HasIndex(p => p.Placa).IsUnique()
                ;
            modelBuilder.Entity<Cliente>()
                .HasMany(p => p.Carros)
                .WithOne(p => p.Cliente)
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
