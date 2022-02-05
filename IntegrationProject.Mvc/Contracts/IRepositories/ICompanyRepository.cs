using IntegrationProject.Mvc.Entities;
using System.Collections.Generic;

namespace IntegrationProject.Mvc.Contracts.IRepositories
{
    public interface ICompanyRepository
    {
        List<CompanyEntity> Get();

        CompanyEntity Get(int id);

        void Update(CompanyEntity entity);

        void Delete(int id);    
    }
}