using ApiTest.Models;

namespace ApiTest.Services
{
    public class BeerService : IBeerService
    {
        private List<Beer> _beers = new List<Beer>()
        {
            new Beer(){Id = 1, Branch="Modelo",Name="Corona"},            
            new Beer(){Id = 2, Branch="Pikantus",Name="Erdin"}
        };

        public IEnumerable<Beer> Get()
        {
            return _beers;
        }

        public Beer? Get(int id)
        {
            return _beers.FirstOrDefault(x => x.Id == id);
        }
    }
}
