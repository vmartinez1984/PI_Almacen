using Microsoft.EntityFrameworkCore;

namespace PruebaDeConcepto.Api.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pais> Pais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pais>().HasData(
                new Pais { Nombre = "España", Habitantes = 46000000 },
                new Pais { Nombre = "Alemania", Habitantes = 83000000 },
                new Pais { Nombre = "Francia", Habitantes = 65000000 },
                new Pais { Nombre = "Italia", Habitantes = 61000000 }
                );
        }
    }
}
