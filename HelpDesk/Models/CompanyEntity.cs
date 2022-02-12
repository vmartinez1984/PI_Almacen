using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HelpDesk.Models
{
    public class CompanyEntity : AddressEntity

    {
        [Required]
        [MaxLength(150)]
        [Display(Name ="Nombre")]
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
    }
}