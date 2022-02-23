using System;
using System.ComponentModel.DataAnnotations;

namespace Activities.Dtos
{
    public class CommentDto
    {
        [Display(Name = "Contenido")]
        public string Content { get; set; }

        [Display(Name = "Name")]
        public string UserFullName { get; set; }

        [Display(Name = "Fecha")]
        public DateTime DateRegistration { get; set; }
    }
}
