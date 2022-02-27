using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDesk.Models
{
    public class PersonEntity : BaseEntity
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

        [ForeignKey(nameof(BranchEntity))]
        [Display(Name = "Dependencia")]
        public int BranchId { get; set; }

        [Display(Name = "Dependencia")]
        public virtual BranchEntity Branch { get; set; }

        public string FullName { get { return $"{this.Name} {this.LastName}"; } }

        [NotMapped]
        public int CompanyId { get; set; }
    }
}
