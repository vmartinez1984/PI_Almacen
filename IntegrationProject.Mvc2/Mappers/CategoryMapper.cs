using IntegrationProject.Mvc2.Entities;
using IntegrationProject.Mvc2.Models;

namespace IntegrationProject.Mvc2.Mappers
{
    public class CategoryMapper: AutoMapper.Profile
    {
        public CategoryMapper()
        {
           CreateMap<CategoryEntity,CategoryViewModel>().ReverseMap();
        }
    }
}