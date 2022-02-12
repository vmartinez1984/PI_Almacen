using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDesk.Models
{
    public class CompanyEntity : AddressEntity

    {
        [Required]
        [MaxLength(150)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [MaxLength(255)]
        [Display(Name = "Notas")]
        public string Note { get; set; }

        //[Required]
        //[MaxLength(500)]
        //[Display(Name = "Dirección")]
        //public string Address { get; set; }
        //public virtual AddressEntity Address { get; set; }

        public virtual List<BranchEntity> ListBranches { get; set; }

        [NotMapped]
        [Display(Name = "Dependencias")]
        public int CountDependencys { get; set; }
        
        [NotMapped]
        [Display(Name = "Personas")]
        public int CountPersons { get; set; }
        
        [NotMapped]
        [Display(Name = "Productos")]
        public int CountProducts { get; set; }
    }
}