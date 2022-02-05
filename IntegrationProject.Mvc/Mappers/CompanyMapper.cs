namespace IntegrationProject.Mvc.Mappers
{
    public class CompanyMapper: AutoMapper.Profile
    {
        public CompanyMapper()
        {
            CreateMap<Entities.CompanyEntity, Dtos.Inputs.CompanyDtoIn>().ReverseMap();

        }
    }
}
