using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Models
{
    public class CompanyEntity : AddressEntity

    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Note { get; set; }

        public virtual AddressEntity Address { get; set; }
    }
}
