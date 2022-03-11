using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Activities.Models
{
    public class CommentEntity: BaseEntity
    {
        [Required]
        [ForeignKey(nameof(RowEntity))]
        [Display(Name = "Actividad")]
        public int RowId { get; set; }
        public virtual RowEntity Row { get; set; }

        [Required]
        [ForeignKey(nameof(UserEntity))]
        [Display(Name = "Colaborador")]
        public int UserId { get; set; }
        [Display(Name = "Colaborador")]
        public UserEntity User { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Contenido")]
        public string Content { get; set; }
    }
}