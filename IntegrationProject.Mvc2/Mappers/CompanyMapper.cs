using IntegrationProject.Mvc2.Entities;
using IntegrationProject.Mvc2.Models;

namespace IntegrationProject.Mvc2.Mappers
{
    public class CompanyMapper: AutoMapper.Profile
    {
        public CompanyMapper()
        {
            CreateMap<CompanyEntity,CompanyViewModel>().ReverseMap();
        }
    }
}
