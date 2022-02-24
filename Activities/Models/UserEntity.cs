using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Activities.Models
{
    public class UserEntity : BaseEntity
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required]
        [StringLength(12)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required]
        [NotMapped]
        [StringLength(12)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirma contraseña")]
        public string ConfirmPassword { get; set; }

        [Required]
        [ForeignKey(nameof(RoleEntity))]
        [Display(Name = "Rol")]
        public int RoleId { get; set; }

        public virtual RoleEntity Role { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{this.Name} {this.LastName}";
            }
        }        
    }
}
