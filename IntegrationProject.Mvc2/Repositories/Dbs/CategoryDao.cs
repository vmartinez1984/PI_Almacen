using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using IntegrationProject.Mvc2.Entities;
using System;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace IntegrationProject.Mvc2.Repositories.Dbs
{
    public class CategoryDao
    {
        private readonly IConfiguration _configuration;        

        public CategoryDao(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<CategoryEntity> Get()
        {
            try
            {
                List<CategoryEntity> list;
                string query;

                query = "SELECT * FROM Category";
                using (var db = new SqlConnection(_configuration.GetConnectionString(ConnectionSql.StringConnection)))
                {
                    list = db.Query<CategoryEntity>(query).ToList();
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