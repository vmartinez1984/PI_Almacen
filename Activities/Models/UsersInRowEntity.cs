using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Activities.Models
{
    public class UsersInRowEntity: BaseEntity
    {
        [Required]
        [ForeignKey(nameof(UserEntity))]
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }

        //[Required]
        [ForeignKey(nameof(RowEntity))]
        public int? RowId { get; set; }
        public virtual RowEntity Row { get; set; }
    }
}