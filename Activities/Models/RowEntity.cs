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
        public int? ActivityId { get; set; }
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
        [Display(Name = "Estatus")]
        public virtual RowStatusEntity RowStatus { get; set; }

        [Display(Name = "Fecha de fin")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DateStop { get; set; }

        [Display(Name = "Fecha de inicio")]
        public DateTime DateStart { get; set; }

        [Display(Name = "Comentarios")]
        public virtual List<CommentEntity> ListComments { get; set; }

        [Display(Name = "Colaboradores")]
        public virtual List<UsersInRowEntity> ListUsers { get; set; }

        [Display(Name = "Archivos")]
        public virtual List<FileEntity> ListFiles { get; set; }
    }
}