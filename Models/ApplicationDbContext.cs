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

           
            modelBuilder.Entity<BakimFiyatlari>()
        .HasKey(b => b.BakimID); 

            modelBuilder.Entity<BakimFiyatlari>().HasData(
                new BakimFiyatlari { BakimID = 1, BakimAdi = "Yağ Değişimi", Ucret = 500 },
                new BakimFiyatlari { BakimID = 2, BakimAdi = "Buji Değişimi", Ucret = 300 }
            );

            
            modelBuilder.Entity<Islemler>()
                .HasKey(i => i.IslemID);

            modelBuilder.Entity<Islemler>()
                .HasOne(i => i.Arac) 
                .WithMany() 
                .HasForeignKey(i => i.AracID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Islemler>()
                .HasOne(i => i.BakimFiyat) 
                .WithMany() 
                .HasForeignKey(i => i.BakimID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
