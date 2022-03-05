using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expenses.Models
{
    public class Expense
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
        [Display(Name = "Categoria")]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        [Display(Name = "Categoria")]
        public virtual Category Category { get; set; }

        [Required]
        [ForeignKey(nameof(Period))]
        [Display(Name = "Periodo")]
        public int PeriodId { get; set; }

        [Display(Name = "Periodo")]
        public virtual Period Period { get; set; }

        [Required]
        [Display(Name = "Fecha de registro")]
        public DateTime DateRegister { get; set; } = DateTime.Now;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
