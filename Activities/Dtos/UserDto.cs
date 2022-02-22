using System.ComponentModel.DataAnnotations;

namespace Activities.Dtos
{
    public class UserInRowDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Nombre")]
        public string FullName { get; set; }
    }
}