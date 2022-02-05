using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using ServicioDummy.Core.Entities;

namespace ServicioDummy.Respository
{
    public interface IEmployeeRepository
    {
        Task<EmployeeEntity> Get(int id);
        Task<List<EmployeeEntity>> Get();
    }
}
