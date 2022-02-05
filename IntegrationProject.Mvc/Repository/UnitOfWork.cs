using IntegrationProject.Mvc.Contracts;
using IntegrationProject.Mvc.Contracts.IRepositories;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace IntegrationProject.Mvc.Repository
{
    public class UnitOfWork : IUnitOfWork, IRepositoryFactory
    {
        private SqlConnection Connection;
        public ICompanyRepository CompanyRepository => throw new System.NotImplementedException();

        public UnitOfWork(IConfiguration configuration)
        {
            this.Connection = new SqlConnection(configuration.GetConnectionString("StringConnection"));
            this.Connection.Open();
        }
    }
}