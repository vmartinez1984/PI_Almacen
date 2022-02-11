using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Activities.Dtos
{
    public class RowDto
    {
        public int Id { get; set; }
        public string Status { get; set; }


        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }


        [Display(Name = "Fin del jale")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DateStop { get; set; }

        [Display(Name = "Inicio del jale")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DateStart { get; set; }

        [Display(Name = "Fecha de Registro")]
        public DateTime DateRegistration { get; set; }

        [Display(Name ="Lista de carnales")]
        public List<UserDto> ListUsers { get; set; }

        [Display(Name = "Lista de documentos")]
        public List<FileDto> ListFiles { get; set; }
    }
}
