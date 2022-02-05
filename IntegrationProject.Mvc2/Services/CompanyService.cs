using System.Collections.Generic;
using IntegrationProject.Mvc2.Models;
using IntegrationProject.Mvc2.Entities;
using AutoMapper;
using IntegrationProject.Mvc2.Repositories.Dbs;

namespace IntegrationProject.Mvc2.Services
{
    public class CompanyService
    {
        private IMapper _mapper;
        private CompanyDao _companyDao;

        public CompanyService(IMapper mapper, Repositories.Dbs.CompanyDao companyDao)
        {
            _mapper = mapper;
            _companyDao = companyDao;
        }

        public List<CompanyViewModel> Get()
        {
            try
            {
                List<CompanyViewModel> list;
                List<CompanyEntity> entities;

                entities = _companyDao.Get();
                list = _mapper.Map<List<CompanyViewModel>>(entities);

                return list;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
