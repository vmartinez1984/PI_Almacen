using System.ComponentModel.DataAnnotations;

namespace Activities.Dtos
{
    public class UserLoginDto
    {
        [Required]
        [StringLength(50)]
        [Display(Name ="Usuario")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(12)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }
}