using System;
using System.ComponentModel.DataAnnotations;

namespace Activities.Models
{
    public class UserOnlineEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }

        [Required]
        public DateTime DateRegistration { get; set; } = DateTime.Now;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
