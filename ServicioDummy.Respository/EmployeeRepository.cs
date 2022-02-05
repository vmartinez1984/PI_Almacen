using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicioDummy.Core.Entities;
using System.Data;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ServicioDummy.Respository
{
    public class EmployeeRepository:IEmployeeRepository
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
        public async Task<EmployeeEntity> Get(int id)
        {
            try
            {
                string query;
                EmployeeEntity employee;

                query = $"select * from Employee where id ={id}";
                using (IDbConnection dbConnection = Connection)
                {
                    employee = null;
                    await Task.Run(() =>
                    {
                        employee = dbConnection.Query<EmployeeEntity>(query)
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

        public async Task<List<EmployeeEntity>> Get()
        {
            try
            {
                string query;
                List<EmployeeEntity> employee;

                query = $"select * from Employee";
                using (IDbConnection dbConnection = Connection)
                {
                    employee = new List<EmployeeEntity>();
                    await Task.Run(() =>
                    {
                        employee = dbConnection.Query<EmployeeEntity>(query)
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
