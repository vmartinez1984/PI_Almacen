using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Activities.Models
{
    public class CommentEntity: BaseEntity
    {
        [Required]
        [ForeignKey(nameof(RowEntity))]
        public int IdRow { get; set; }

        [Required]
        [ForeignKey(nameof(UserEntity))]
        public int IdUser { get; set; }

        [Required]
        [StringLength(150)]
        public string Content { get; set; }
    }
}