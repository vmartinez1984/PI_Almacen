using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDesk.Models
{
    public class TicketSubcategory:BaseCatalogue
    {
        [Required]
        [Display(Name ="Categoria")]
        [ForeignKey(nameof(TicketCategory))]
        public int TicketCategoryId { get; set; }
        public virtual TicketCategory TicketCategory { get; set; }
    }
}
