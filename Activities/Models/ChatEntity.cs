using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Activities.Models
{
    public class ChatEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(UserEntity))]
        public int UserIdSource { get; set; }
        [NotMapped]
        public virtual UserEntity UserSource { get; set; }

        [Required]
        [StringLength(250)]
        public string Message { get; set; }

        [Required]
        [ForeignKey(nameof(UserEntity))]
        public int UserIdDestiny { get; set; }
        [NotMapped]
        public virtual UserEntity UserDestiny { get; set; }

        [Required]
        public DateTime DateRegistration { get; set; } = DateTime.Now;
    }
}
