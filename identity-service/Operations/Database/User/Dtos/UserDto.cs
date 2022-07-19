namespace Identity.Operations.Database.User.Dtos
{
    public class UserDto : User
    {
        public string? TenantTitle { get; set; }
        public string? RoleTitle { get; set; }
    }
}
