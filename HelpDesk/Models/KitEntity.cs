using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDesk.Models
{
    public class KitEntity : BaseEntity
    {
        [Required]
        [Display(Name = "Código")]
        public string Code { get; set; }

        [Required]
        [Display(Name = "Fecha de asignación")]
        [DataType(DataType.Date)]
        [NotMapped]
        public DateTime DateAssignment { get; set; }

        public List<ProductAssignmentEntity> ListProductAssignments { get; set; }
    }
}