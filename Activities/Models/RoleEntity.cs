using System;
using System.ComponentModel.DataAnnotations;

namespace Activities.Models
{
    public class RoleEntity : BaseEntity
    {
        [Required]
        [Display(Name = "Nombre")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(255)]
        public string Description { get; set; }
    }
}