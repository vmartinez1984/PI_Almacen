using AutoMapper;
using IntegrationProject.Mvc.Contracts;
using IntegrationProject.Mvc.Contracts.IServices;

namespace IntegrationProject.Mvc.Services
{
    public class ServiceFactory : Contracts.IServices.IServiceFactory
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private IRepositoryFactory _repositoryFactory;
        private ICompanyService _companyService;
            
        public ServiceFactory(AutoMapper.IMapper mapper, Contracts.IUnitOfWork unitOfWork, IRepositoryFactory repositoryFactory)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repositoryFactory = repositoryFactory;
        }

        public ICompanyService CompanyService =>
            _companyService ?? (_companyService = new CompanyService(_mapper,_unitOfWork));
    }
}
