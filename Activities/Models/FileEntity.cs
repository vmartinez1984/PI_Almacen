using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Activities.Models
{
    public class FileEntity : BaseCataloge
    {
        [Required]
        public string Url { get; set; }

        [Required]
        [ForeignKey(nameof(RowEntity))]
        public int IdRow { get; set; }

        [Required]
        [ForeignKey(nameof(UserEntity))]
        public int IdUser { get; set; }
    }
}