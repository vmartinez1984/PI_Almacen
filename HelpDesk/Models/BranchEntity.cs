using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HelpDesk.Models
{
    public class BranchEntity : AddressEntity
    {
        [Required]
        [Display(Name = "Nombre")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Teléfono")]
        [StringLength(255)]
        public string Phone { get; set; }

        [Display(Name = "Correo electrónico")]
        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(1000)]
        [Display(Name = "Notas")]
        public string Note { get; set; }

        public virtual AddressEntity Address { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(CompanyEntity))]
        [Range(1, 10)]
        public int IdCompany { get; set; }
        public virtual List<CompanyEntity> ListCompanies { get; set; }


        [Required]
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(TypeBranchEntity))]
        [Range(1,10)]
        public int IdTypeBranch { get; set; }

        public virtual List<TypeBranchEntity> ListTypeBranchs { get; set; }
    }
}
