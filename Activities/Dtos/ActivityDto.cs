using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Activities.Dtos
{
    public class ActivityDto
    {
        public int Id { get; set; }

        [Display(Name="Nombre")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }
        public List<RowDto> ListRows { get; set; }
    }
}