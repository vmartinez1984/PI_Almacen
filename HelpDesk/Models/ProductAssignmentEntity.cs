using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Models
{
    public class ProductAssignmentEntity : BaseEntity
    {
        [Required]
        [ForeignKey(nameof(PersonEntity))]
        [Display(Name = "Producto")]
        public int ProductId { get; set; }
        [Display(Name = "Producto")]
        public virtual ProductEntity Product { get; set; }

        [Required]
        [ForeignKey(nameof(PersonEntity))]
        [Display(Name = "Persona")]
        public int PersonId { get; set; }
        [Display(Name = "Persona")]
        public virtual PersonEntity Person { get; set; }

        [Required]
        [ForeignKey(nameof(UserEntity))]
        [Display(Name = "Usuario")]
        public int UserId { get; set; }
        [Display(Name = "Usuario")]
        public virtual UserEntity User { get; set; }

        [Required]
        [Display(Name = "Fecha de asignación")]
        [DataType(DataType.Date)]
        public DateTime DateAssignment { get; set; }

        [Display(Name = "Kit")]
        [ForeignKey(nameof(KitEntity))]
        public int KitId { get; set; }
        public virtual KitEntity Kit { get; set; }
    }
}
