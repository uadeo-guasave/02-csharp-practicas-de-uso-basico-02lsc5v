using System.ComponentModel.DataAnnotations.Schema;

namespace _02_csharp_primeros_pasos.Models
{

    [Table("roles_has_permissions")]
    public class RoleHasPermission
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        // Controlado por EFCore
        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }
}