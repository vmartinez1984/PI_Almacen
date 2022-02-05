using System;

namespace IntegrationProject.Mvc.Dtos.Outputs
{
    public class CompanyDtoOut
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime DateRegistration { get; set; }
    }
}