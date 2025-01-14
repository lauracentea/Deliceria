
using Microsoft.EntityFrameworkCore;
using Deliceria.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // Ajustează acest namespace în funcție de locația modelelor tale

namespace Deliceria.Data
{
    public class DeliceriaContext : IdentityDbContext<User, IdentityRole, string>
    {
        // Constructor
        public DeliceriaContext(DbContextOptions<DeliceriaContext> options)
            : base(options)
        {
        }

        // DbSet-uri
        public DbSet<Produs> Produse { get; set; }
        public DbSet<Comanda> Comenzi { get; set; }
        public DbSet<Utilizator> Utilizatori { get; set; }
        public DbSet<Recenzie> Recenzii { get; set; }
        public DbSet<DetaliiComanda> DetaliiComenzi { get; set; }

        // Configurarea relațiilor
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relația Recenzie -> Utilizator (Client)
            modelBuilder.Entity<Recenzie>()
                .HasOne(r => r.Client) // Asigură-te că Client este definit în modelul Recenzie
                .WithMany(u => u.Recenzii)
                .HasForeignKey(r => r.ClientId);

            // Relația Recenzie -> Produs
            modelBuilder.Entity<Recenzie>()
                .HasOne(r => r.Produs)
                .WithMany()
                .HasForeignKey(r => r.ProdusId);

            // Relația DetaliiComanda -> Comanda
            modelBuilder.Entity<DetaliiComanda>()
                .HasOne(dc => dc.Comanda)
                .WithMany(c => c.DetaliiComanda)
                .HasForeignKey(dc => dc.ComandaId);

            // Relația DetaliiComanda -> Produs
            modelBuilder.Entity<DetaliiComanda>()
                .HasOne(dc => dc.Produs)
                .WithMany()
                .HasForeignKey(dc => dc.ProdusId);
        }
    }
}