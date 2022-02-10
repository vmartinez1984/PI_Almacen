using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Models
{
    public class BaseCatalogue: BaseEntity
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Description { get; set; }
    }
}
