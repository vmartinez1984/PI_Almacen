using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDesk.Models
{
    public class TicketEntity: BaseEntity
    {
        [Required]
        [StringLength(20)]
        [Display(Name = "Título")]
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Required]
        [Display(Name ="Usuario")]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }

        [Required]
        [Display(Name = "Estatus")]
        [ForeignKey(nameof(TicketStatus))]
        public int TicketStatusId { get; set; }
        public TicketStatusEntity TicketStatus { get; set; }

        [Required,Display(Name ="Subcategoria")]
        [ForeignKey(nameof(TicketSubcategory))]
        public int TicketSubcategoryId { get; set; }
        public TicketSubcategory TicketSubcategory { get; set; }
    }
}
