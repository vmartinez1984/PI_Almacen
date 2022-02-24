using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Activities.Dtos
{
    public class FileDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        [Required]
        [NotMapped]
        [Display(Name = "Archivo")]
        public IFormFile FormFile { get;  set; }        

        public int RowId { get; set; }
    }
}