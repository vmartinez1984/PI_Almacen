using InyeccionDeDependenciaConDapper.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InyeccionDeDependenciaConDapper.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> Get(int id);
        Task<List<Employee>> Get();
    }
}
