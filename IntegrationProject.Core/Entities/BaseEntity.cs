using System;

namespace IntegrationProject.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }        
        public bool IsActive { get; set; }
        public DateTime DateRegistration { get; set; }
    }
}
