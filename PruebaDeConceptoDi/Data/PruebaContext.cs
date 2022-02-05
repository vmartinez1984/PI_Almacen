using Microsoft.EntityFrameworkCore;
using PruebaDeConceptoDi.Models;

namespace PruebaDeConceptoDi.Data
{
    public class PruebaContext: DbContext
    {
        public PruebaContext(DbContextOptions<PruebaContext> options)
            : base(options) { }

        public DbSet<Pelicula> Peliculas { get; set; }
    }
}
