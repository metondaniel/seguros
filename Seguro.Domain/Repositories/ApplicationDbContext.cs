using Crud.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.Repository
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Segurado> Segurados { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Seguro> Seguros { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Seguro>()
                .HasOne(s => s.Veiculo)
                .WithMany()
                .HasForeignKey(s => s.VeiculoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Seguro>()
                .HasOne(s => s.Segurado)
                .WithMany()
                .HasForeignKey(s => s.SeguradoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
