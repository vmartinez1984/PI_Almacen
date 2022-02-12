using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace Activities.Models
{
    public class RowEntity : BaseCataloge
    {
        [Required]
        [ForeignKey(nameof(ActivityEntity))]
        public int ActivityId { get; set; }

        [Required]
        [ForeignKey(nameof(UserEntity))]
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }

        [Required]
        [ForeignKey(nameof(RowStatusEntity))]
        public int RowStatusId { get; set; }
        public virtual RowStatusEntity RowStatus { get; set; }

        [Display(Name ="Fecha de vencimiento")]
        public DateTime DateStop { get; set; }

        [Display(Name = "Fecha de inicio")]
        public DateTime DateStart { get; set; }        

        public virtual List<CommentEntity> ListComments { get; set; }
    }
}