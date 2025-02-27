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
    }
}
