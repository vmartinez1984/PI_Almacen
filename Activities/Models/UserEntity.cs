using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Activities.Models
{
    public class UserEntity: BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(12)]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Phone()]
        public string ConfirmPassword { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(RoleEntity))]
        public int IdRol { get; set; }

        public List<RoleEntity> Role { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(255)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Email { get; set; }
    }
}
