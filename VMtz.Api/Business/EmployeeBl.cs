using System;
using System.Collections.Generic;
using VMtz.Api.Dtos.Outputs;
using VMtz.Api.Entities;
using VMtz.Api.Persistence;

namespace VMtz.Api.Business
{
    public class EmployeeBl
    {
        public static List<EmployeeDtoOut> Get()
        {
            try
            {
                List<EmployeeDtoOut> list;
                List<EmployeeEntity> entities;
                EmployeeDao employeeDao;

                employeeDao = new EmployeeDao();
                entities = employeeDao.Get();
                list = Mappers(entities);

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static List<EmployeeDtoOut> Mappers(List<EmployeeEntity> entities)
        {
            List<EmployeeDtoOut> list;

            list = new List<EmployeeDtoOut>();
            entities.ForEach(entity =>
            {
                list.Add(new EmployeeDtoOut
                {
                    Id = entity.Id,
                    Name = entity.Name
                });
            });

            return list;
        }
    }
}
