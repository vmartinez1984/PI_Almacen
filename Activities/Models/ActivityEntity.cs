using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Activities.Models
{
    public class ActivityEntity: BaseCataloge
    {      
        [Required]
        [ForeignKey(nameof(UserEntity))]
        public int IdUser { get; set; }
        public virtual UserEntity User { get; set; }

        [Required]
        [ForeignKey(nameof(ActivityStatusEntity))]
        public int IdActivityStatus { get; set; }
        public virtual ActivityStatusEntity ActivityStatus { get; set; }

        public virtual List<RowEntity> ListRows { get; set; }
    }
}