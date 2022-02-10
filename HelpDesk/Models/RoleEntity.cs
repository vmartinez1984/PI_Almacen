namespace HelpDesk.Models
{
    public class RoleEntity:BaseEntity
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
