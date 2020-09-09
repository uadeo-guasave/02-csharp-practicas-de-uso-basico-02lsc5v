using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _02_csharp_primeros_pasos.Models
{

    [Table("roles")]
    public class Role
    {
        public int Id { get; set; }

        [Required, MaxLength(16)]
        public string Name { get; set; }

        [Required, MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public int Level { get; set; }

        // Controlado por EFCore
        public List<User> Users { get; set; }
        public List<RoleHasPermission> RolesHasPermissions { get; set; }
        
    }
}