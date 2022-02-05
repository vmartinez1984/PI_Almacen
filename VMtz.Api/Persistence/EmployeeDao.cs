using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using VMtz.Api.Entities;

namespace VMtz.Api.Persistence
{
    public class EmployeeDao
    {
        public List<EmployeeEntity> Get()
        {
            try
            {
                List<EmployeeEntity> list;
                string query;

                query = "SELECT * FROM Employee";
                using (var db = new SqlConnection())
                {
                    list = db.Query<EmployeeEntity>(query).ToList();
                }

                return list;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
