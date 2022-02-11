using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Activities.Models
{
    public class ActivityEntity: BaseCataloge
    {      
        [Required]
        [ForeignKey(nameof(UserEntity))]
        public int IdUser { get; set; }

        [Required]
        [ForeignKey(nameof(ActivityStatusEntity))]
        public int IdActivityStatus { get; set; }
    }
}