namespace IntegrationProject.Mvc2.Entities
{
    public class CompanyEntity: BaseEntity
    {
        public string Name { get; set; }
        public string Notes { get; set; }
        public int IdPerson { get; set; }
    }
}