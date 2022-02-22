using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Activities.Models
{
    public class UsersInRowEntity: BaseEntity
    {
        [Required(ErrorMessage = "El colaborador es obligatorio")]
        [ForeignKey(nameof(UserEntity))]
        [Display(Name ="Colaborador")]
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }

        //[Required]
        [ForeignKey(nameof(RowEntity))]
        [Display(Name = "Actividad")]
        public int? RowId { get; set; }
        public virtual RowEntity Row { get; set; }
    }
}