using System;
using System.ComponentModel.DataAnnotations;

namespace Files.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;
        public DateTime DateRegistration { get; set; } = DateTime.Now;
    }
}
