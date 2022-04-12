using ApiTest.Models;

namespace ApiTest.Services
{
    public interface IBeerService
    {
        public IEnumerable<Beer> Get();

        public Beer? Get(int id);
    }
}
