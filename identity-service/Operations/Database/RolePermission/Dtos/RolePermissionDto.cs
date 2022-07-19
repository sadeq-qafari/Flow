namespace Identity.Operations.Database.RolePermission.Dtos
{
    public class RolePermissionDto : RolePermission
    {
        public string? RoleTitle { get; set; }
        public string? PermissionTitle { get; set; }
    }
}
