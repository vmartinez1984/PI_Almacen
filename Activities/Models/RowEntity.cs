using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Activities.Models
{
    public class RowEntity : BaseCataloge
    {
        [Required]
        [ForeignKey(nameof(ActivityEntity))]
        public int IdActivity { get; set; }

        [Required]
        [ForeignKey(nameof(UserEntity))]
        public int IdUser { get; set; }

        [Required]
        [ForeignKey(nameof(RowStatusEntity))]
        public int IdRowStatus { get; set; }
        public virtual RowStatusEntity RowStatus { get; set; }

        [Display(Name ="Fecha de vencimiento")]
        public DateTime DateStop { get; set; }

        [Display(Name = "Fecha de inicio")]
        public DateTime DateStart { get; set; }        
    }
}