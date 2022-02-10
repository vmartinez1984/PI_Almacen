using AutoMapper;
using IntegrationProject.Mvc.Contracts;
using IntegrationProject.Mvc.Dtos.Inputs;
using IntegrationProject.Mvc.Dtos.Outputs;
using System.Collections.Generic;

namespace IntegrationProject.Mvc.Services
{
    public class CompanyService : Contracts.IServices.ICompanyService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        //private IRepositoryFactory _repositoryFactory;

        public CompanyService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<CompanyDtoOut> Get()
        {
            List<CompanyDtoOut> list;
            List<Entities.CompanyEntity> entities;

            //entities = _unitOfWork.
            //list = _mapper.Map<List<CompanyDtoOut>>(entities);

            return null;
        }

        public CompanyDtoOut Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(CompanyDtoIn company)
        {
            throw new System.NotImplementedException();
        }
    }
}
