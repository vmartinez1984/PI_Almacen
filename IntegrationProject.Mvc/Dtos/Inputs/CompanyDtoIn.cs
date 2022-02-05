using System;

namespace IntegrationProject.Mvc.Dtos.Inputs
{
    public class CompanyDtoIn
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime DateRegistration { get; set; }

    }
}