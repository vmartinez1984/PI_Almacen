using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Models
{
    public class AddressEntity:BaseEntity
    {
        //[Required]        
        //[StringLength(5,MinimumLength = 5)]
        //[Display(Name = "Código postal")]
        //public string ZipCode { get; set; }

        [Required]
        [StringLength (500)]
        [Display(Name = "Dirección")]
        public string Street { get; set; }        
    }
}