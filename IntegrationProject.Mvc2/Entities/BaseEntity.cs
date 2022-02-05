namespace IntegrationProject.Mvc2.Entities
{
    public class BaseEntity
    {        
        public int Id { get; set; }
                
        public System.DateTime DateRegistration { get; set; }
                
        public bool IsActive { get; set; }
    }
}
