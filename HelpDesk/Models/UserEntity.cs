using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDesk.Models
{
    public class UserEntity : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(12)]
        public string Password { get; set; }

        [NotMapped]
        [StringLength(12)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [ForeignKey(nameof(RoleEntity))]
        public int RolId { get; set; }

        public virtual List<RoleEntity> Role { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(255)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [NotMapped]
        public string FullName { get { return $"{Name} {LastName}"; } }
    }
}
