using System;
using System.ComponentModel.DataAnnotations;

namespace Expenses.Models
{
    public class Entry
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        [DataType(DataType.Currency)]
        public int Amount { get; set; }

        [Required]
        [Display(Name = "Fecha de registro")]
        public DateTime DateRegister { get; set; } = DateTime.Now;

        [Required]
        public int PeriodId { get; set; }
        public virtual Period Period { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
