using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Models
{
    public class ProductAssignmentEntity: BaseEntity
    {
        [Required]
        [ForeignKey(nameof(PersonEntity))]
        public int PersonId { get; set; }

        [Required]
        [ForeignKey(nameof(UserEntity))]
        public int UserId { get; set; }

        [Required]        
        public DateTime DateAssignment { get; set; }
    }
}
