using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
                

        [Required]
        [ForeignKey(nameof(CompanyEntity))]
        [Range(1, 10)]
        [Display(Name = "Compañia")]
        public int CompanyId { get; set; }
        public virtual CompanyEntity Company { get; set; }


        [Required]
        [ForeignKey(nameof(BranchTypeEntity))]        
        [Display(Name = "Tipo")]
        public int BranchTypeId { get; set; }

        public virtual BranchTypeEntity TypeBranch { get; set; }        

        [NotMapped]
        [Display(Name= "Personas")]
        public int CountPersons { get; internal set; }

        public virtual List<PersonEntity> ListPerson { get; set; }
    }
}