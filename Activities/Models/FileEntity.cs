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
        public virtual RowEntity Row { get; set; }

        [Required]
        [ForeignKey(nameof(UserEntity))]
        public int IdUser { get; set; }
        public virtual UserEntity User { get; set; }
    }
}