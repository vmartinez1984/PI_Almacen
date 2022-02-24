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
        [Display(Name = "Grupo de actividades")]
        public int ActivityId { get; set; }
        public virtual ActivityEntity Activity { get; set; }

        [Required]
        [ForeignKey(nameof(UserEntity))]
        [Display(Name = "Colaborador")]
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }

        [Required]
        [ForeignKey(nameof(RowStatusEntity))]
        [Display(Name = "Estatus")]
        public int RowStatusId { get; set; }
        public virtual RowStatusEntity RowStatus { get; set; }

        [Display(Name = "Fecha de vencimiento")]
        public DateTime DateStop { get; set; }

        [Display(Name = "Fecha de inicio")]
        public DateTime DateStart { get; set; }

        public virtual List<CommentEntity> ListComments { get; set; }

        public virtual List<FileEntity> ListFiles { get; set; }
    }
}