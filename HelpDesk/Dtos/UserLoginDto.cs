using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Dtos
{
    public class UserLoginDto
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required]
        [StringLength(12)]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
