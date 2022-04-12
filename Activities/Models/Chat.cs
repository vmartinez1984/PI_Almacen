using System;
using System.ComponentModel.DataAnnotations;

namespace Activities.Models
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserIdSource { get; set; }
        public virtual UserEntity UserSource { get; set; }

        [Required]
        [StringLength(250)]
        public string Message { get; set; }

        [Required]
        public int UserIdDestiny { get; set; }
        public virtual UserEntity UserDestiny { get; set; }

        [Required]
        public DateTime DateRegistration { get; set; } = DateTime.MinValue;
    }
}
