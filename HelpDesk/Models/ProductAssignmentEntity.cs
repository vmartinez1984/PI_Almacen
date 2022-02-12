using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Models
{
    public class ProductAssignmentEntity: BaseEntity
    {
        [Required]
        [ForeignKey(nameof(PersonEntity))]
        public int ProductId { get; set; }
        public virtual ProductEntity Product { get; set; }

        [Required]
        [ForeignKey(nameof(PersonEntity))]
        public int PersonId { get; set; }
        public virtual PersonEntity Person { get; set; }    

        [Required]
        [ForeignKey(nameof(UserEntity))]
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }

        [Required]       
        [Display(Name = "Fecha de asignación")]
        public DateTime DateAssignment { get; set; }
    }
}
