using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Activities.Models
{
    public class BaseCataloge:BaseEntity
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
                
        [StringLength(255)]
        [Display(Name = "Descripción")]
        public string Description { get; set; }
    }
}