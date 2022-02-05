using InyeccionDeDependenciaConDapper.Repositories;
using InyeccionDeDependenciaConDapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace InyeccionDeDependenciaConDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Employee> list;

                list =await _employeeRepository.Get();

                return Ok(list);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
