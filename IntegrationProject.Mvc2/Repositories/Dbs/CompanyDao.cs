using System.Collections.Generic;
using IntegrationProject.Mvc2.Entities;

namespace IntegrationProject.Mvc2.Repositories.Dbs
{
    public class CompanyDao
    {
        public List<CompanyEntity> Get()
        {
            try
            {
                List<CompanyEntity> list;

                list = new List<CompanyEntity>();
                list.Add(new CompanyEntity
                {
                    Id = 1,
                    DateRegistration = System.DateTime.Now,
                    IsActive = true,
                    Name = "SkyLine",
                    Notes = "Datos de prueba"
                });

                return list;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}