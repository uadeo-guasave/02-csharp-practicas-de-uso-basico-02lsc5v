using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _02_csharp_primeros_pasos.Models
{

    [Table("permissions")]
    public class Permission
    {
        public int Id { get; set; }

        [Required, MaxLength(16)]
        public string Name { get; set; }

        [Required, MaxLength(200)]
        public string Description { get; set; }

        // Controlado por EFCore
        public List<RoleHasPermission> RolesHasPermissions { get; set; }
    }
}