using System.Collections.Generic;

namespace IntegrationProject.Core.Contracts.IServices
{
    public interface ICompanyService
    {
        List<U> Get<U, T>();

        U Get<U, T>(int id);

        U Update<U, T>(T resquest);

        void Delete(int id);
    }
}