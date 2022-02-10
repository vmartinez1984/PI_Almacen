using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Models
{
    public class AddressEntity:BaseEntity
    {
        [Required]        
        [StringLength(5,MinimumLength = 5)]
        public string ZipCode { get; set; }

        [Required]
        [StringLength (500)]
        public string Street { get; set; }        
    }
}