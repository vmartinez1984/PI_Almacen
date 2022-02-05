using IntegrationProject.Mvc.Contracts.IRepositories;

namespace IntegrationProject.Mvc.Contracts
{
    public interface IRepositoryFactory
    {
        ICompanyRepository CompanyRepository { get; }
    }
}
