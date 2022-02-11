using System.ComponentModel.DataAnnotations;

namespace Activities.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string FullName { get; set; }
    }
}