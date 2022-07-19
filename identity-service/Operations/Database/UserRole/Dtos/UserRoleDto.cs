namespace Identity.Operations.Database.UserRole.Dtos
{
    public class UserRoleDto : UserRole
    {
        public string? UserTitle { get; set; }
        public string? RoleTitle { get; set; }
        public string? BranchTitle { get; set; }
    }
}
