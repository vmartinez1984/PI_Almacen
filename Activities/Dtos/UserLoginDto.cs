using System.ComponentModel.DataAnnotations;

namespace Activities.Dtos
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Escriba el usuario")]
        [StringLength(50)]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Escriba la contraseña")]
        [DataType(DataType.Password)]
        [StringLength(12)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }
}