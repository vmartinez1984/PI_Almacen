using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Models
{
    public class PersonEntity: BaseEntity
    {
        [Required]
        [Display(Name = "Nombre")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        [StringLength(255)]
        public string LastName { get; set; }

        [Display(Name = "Teléfono")]
        [StringLength(255)]
        public string Phone { get; set; }

        [Display(Name = "Correo electrónico")]
        [StringLength(255)]
        public string Email { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(BranchEntity))]
        public int IdBranch { get; set; }        
    }
}
