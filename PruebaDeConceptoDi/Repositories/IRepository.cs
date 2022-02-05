using PruebaDeConceptoDi.Models;
using System.Collections.Generic;

namespace PruebaDeConceptoDi.Repositories
{
    public interface IRepository
    {
        List<Pelicula> Obtener();

        Pelicula Obtener(int id);
    }
}
