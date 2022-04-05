using MongoDB.Driver;
using MvcMongoDb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcMongoDb.Services
{
    public class BeerServices
    {
        private readonly IMongoCollection<Beer> _beers;

        public BeerServices(IBarSettings barSettings)
        {
            var mongoClient = new MongoClient(barSettings.Server);
            var dataBase = mongoClient.GetDatabase(barSettings.Database);
            _beers = dataBase.GetCollection<Beer>(barSettings.Collection);
        }

        public List<Beer> Get()
        {
            return _beers.Find(x => true).ToList();
        }

        public async Task AddAsync(Beer beer) => await _beers.InsertOneAsync(beer); 
            
    }
}
