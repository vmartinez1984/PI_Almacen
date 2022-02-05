namespace IntegrationProject.Mvc2.Entities
{
    public class PersonEntity:BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int IdSucursal { get; set; }
    }
}
