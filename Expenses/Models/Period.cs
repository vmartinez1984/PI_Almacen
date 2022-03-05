using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Expenses.Models
{
    public class Period
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de inicio")]
        public DateTime DateStart { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha fin")]
        public DateTime? DateStop { get; set; }

        [Required]
        [Display(Name = "¿Esta activo?")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Ingresos")]
        public virtual List<Entry> ListEntries { get; set; }

        [Display(Name = "Gastos")]
        public virtual List<Expense> ListExpenses { get; set; }

    }
}