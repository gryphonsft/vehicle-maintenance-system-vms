using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AspProject1.Models
{
    public class AraclarContext : DbContext
    {
        public AraclarContext(DbContextOptions<AraclarContext> options)
            : base(options)
        {
        }

        public DbSet<Araclar> Araclar { get; set; }
    }
}
