using System;
using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Fecha de registro")]
        public DateTime DateRegistration { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}