using Microsoft.Extensions.Configuration;

namespace IntegrationProject.Mvc2.Repositories.Dbs
{
    public class RepositoryFactoryDb
    {
        private readonly IConfiguration _configuration;

        public RepositoryFactoryDb(
            IConfiguration configuration,
            CategoryDao categoryDao
        )
        {
            _configuration = configuration;
            CategoryDao = categoryDao;
        }

        public CategoryDao CategoryDao { get; set; }
    }
}
