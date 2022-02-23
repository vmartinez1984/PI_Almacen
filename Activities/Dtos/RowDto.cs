using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Activities.Dtos
{
    public class RowDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
        [Display(Name ="Status")]
        public int RowStatusId { get; set; }
        public int ActivityId { get; set; }


        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }


        [Display(Name = "Fecha de fin")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DateStop { get; set; }

        [Display(Name = "Fecha de inicio")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DateStart { get; set; }

        [Display(Name = "Fecha de Registro")]
        public DateTime DateRegistration { get; set; }

        [Display(Name ="Colaboradores")]
        public List<UserInRowDto> ListUsers { get; set; }

        [Display(Name = "Documentos")]
        public List<FileDto> ListFiles { get; set; }

        [Display(Name = "Comentarios")]
        public List<CommentDto> ListComments { get; set; }
    }
}
