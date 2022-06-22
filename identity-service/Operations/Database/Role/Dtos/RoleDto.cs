using Identity.Operations.Database.RolePermission.Dtos;

namespace Identity.Operations.Database.Role.Dtos
{
    public class RoleDto : Role
    {
        public PermissionCheckList PermissionCheckList { get; set; }
        public string? ServiceTitle { get; set; }
    }
}
