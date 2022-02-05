using Dapper.Core.Entities;
using Dapper.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.Infrastructure.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;
        const string DefaultConnection = "DefaultConnection";

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> AddAsync(Product entity)
        {
            try
            {
                string query;

                entity.AddedOn = DateTime.Now;
                query = "Insert into Products (Name,Description,Barcode,Rate,AddedOn) VALUES (@Name,@Description,@Barcode,@Rate,@AddedOn)";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    entity.Id = await connection.ExecuteAsync(query, entity);
                }

                return entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                string query;

                query = "DELETE FROM Porducts WHERE Id = @Id";
                using (var db = new SqlConnection(_configuration.GetConnectionString(DefaultConnection)))
                {
                    id = await db.ExecuteAsync(query, new { Id = id });
                }

                return id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            try
            {
                List<Product> entities;
                string query;

                query = "SELECT * FROM Products";
                using (var db = new SqlConnection(_configuration.GetConnectionString(DefaultConnection)))
                {
                    entities = new List<Product>();
                    await Task.Run(() =>
                    {
                        entities = db.Query<Product>(query).ToList();
                    });
                }

                return entities;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            try
            {
                var sql = "SELECT * FROM Products WHERE Id = @Id";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QuerySingleOrDefaultAsync<Product>(sql, new { Id = id });
                    return result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> UpdateAsync(Product entity)
        {
            try
            {
                entity.ModifiedOn = DateTime.Now;
                var sql = "UPDATE Products SET Name = @Name, Description = @Description, Barcode = @Barcode, Rate = @Rate, ModifiedOn = @ModifiedOn  WHERE Id = @Id";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(sql, entity);
                    return result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
