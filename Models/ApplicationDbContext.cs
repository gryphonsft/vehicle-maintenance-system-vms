using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AspProject1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Araclar> Araclar { get; set; }
        public DbSet<Kisiler> Kisiler { get; set; }
        public DbSet<Islemler> Islemler { get; set; }
        public DbSet<BakimFiyatlari> BakimFiyatlari { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Araclar>()
         .HasKey(a => a.AracID)
         ;

            // BakimFiyatlari tablosu için Primary Key
            modelBuilder.Entity<BakimFiyatlari>()
        .HasKey(b => b.BakimID); // Anahtar tanımlaması

            modelBuilder.Entity<BakimFiyatlari>().HasData(
                new BakimFiyatlari { BakimID = 1, BakimAdi = "Yağ Değişimi", Ucret = 500 },
                new BakimFiyatlari { BakimID = 2, BakimAdi = "Buji Değişimi", Ucret = 300 }
            );

            // Islemler tablosu için Foreign Key bağlantıları
            modelBuilder.Entity<Islemler>()
                .HasKey(i => i.IslemID);

            modelBuilder.Entity<Islemler>()
                .HasOne(i => i.Arac) // Islemler tablosundaki Arac nesnesi
                .WithMany() // Bir aracın birçok işlemi olabilir
                .HasForeignKey(i => i.AracID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Islemler>()
                .HasOne(i => i.BakimFiyat) // Islemler tablosundaki Bakim nesnesi
                .WithMany() // Bir bakım birçok işlemde olabilir
                .HasForeignKey(i => i.BakimID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
