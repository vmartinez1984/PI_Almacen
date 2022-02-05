using IntegrationProject.Mvc.Dtos.Inputs;
using IntegrationProject.Mvc.Dtos.Outputs;
using System.Collections.Generic;

namespace IntegrationProject.Mvc.Contracts.IServices
{
    public interface ICompanyService
    {
        List<CompanyDtoOut> Get();

        CompanyDtoOut Get(int id);

        void Update(CompanyDtoIn company);

        void Delete(int id);
    }
}