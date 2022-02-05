using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using InyeccionDeDependenciaConDapper.Models;

namespace InyeccionDeDependenciaConDapper.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private IConfiguration _configuration;

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_configuration.GetConnectionString("ConnectionString"));
            }
        }
        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<Employee> Get(int id)
        {
            try
            {
                string query;
                Employee employee;

                query = $"select * from Employee where id ={id}";
                using (IDbConnection dbConnection = Connection)
                {
                    employee = null;
                    await Task.Run(() =>
                    {
                        employee = dbConnection.Query<Employee>(query)
                            .FirstOrDefault();
                    });
                }

                return employee;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Employee>> Get()
        {
            try
            {
                string query;
                List<Employee> employee;

                query = $"select * from Employee";
                using (IDbConnection dbConnection = Connection)
                {
                    employee = new List<Employee>();
                    await Task.Run(() =>
                    {
                        employee = dbConnection.Query<Employee>(query)
                            .ToList();
                    });
                }

                return employee;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
