using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Files.Models
{
    public class Archive : BaseEntity
    {        
        [StringLength(150)]
        public string Name { get; set; }
        
        public string Base64 { get; set; }

        [StringLength(10)]
        public string Extension { get; set; }

        [ForeignKey(nameof(Folder))]
        public int FolderId { get; set; }
        public Folder Folder { get; set; }

        [Required]
        public bool OnlyRead { get; set; }

        [Required]
        [NotMapped]
        [Display(Name = "Archivo")]
        public IFormFile FormFile { get; set; }
     
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
