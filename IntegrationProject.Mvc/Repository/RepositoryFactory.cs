using IntegrationProject.Mvc.Contracts.IRepositories;

namespace IntegrationProject.Mvc.Repository
{
    public class RepositoryFactory : Contracts.IRepositoryFactory
    {
        public ICompanyRepository CompanyRepository => throw new System.NotImplementedException();
    }
}
