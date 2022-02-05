using PruebaDeConceptoDi.Data;
using PruebaDeConceptoDi.Models;
using System.Collections.Generic;
using System.Linq;

namespace PruebaDeConceptoDi.Repositories
{
    public class RepositorySql : IRepository
    {
        PruebaContext Context;

        public RepositorySql(PruebaContext context)
        {
            this.Context = context;
        }
        public List<Pelicula> Obtener()
        {
            return this.Context.Peliculas.ToList();
        }

        public Pelicula Obtener(int id)
        {
            return this.Context.Peliculas.SingleOrDefault(x => x.IdPelicula == id);
        }
    }
}
