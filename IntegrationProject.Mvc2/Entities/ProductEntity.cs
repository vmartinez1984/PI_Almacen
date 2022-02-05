using System;

namespace IntegrationProject.Mvc2.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Mark { get; set; }
        public int IdCategory { get; set; }
        public string SerieNumber { get; set; }
        public string Note { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateStop { get; set; }
    }
}