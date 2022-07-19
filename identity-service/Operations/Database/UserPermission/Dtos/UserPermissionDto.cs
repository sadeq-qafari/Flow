namespace Identity.Operations.Database.UserPermission.Dtos
{
    public class UserPermissionDto : UserPermission
    {
        public string? UserTitle { get; set; }
        public string? PermissionName { get; set; }
        public string? BranchTitle { get; set; }
    }
}
