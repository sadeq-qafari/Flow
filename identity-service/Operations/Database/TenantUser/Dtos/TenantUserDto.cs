namespace Identity.Operations.Database.TenantUser.Dtos
{
    public class TenantUserDto : TenantUser
    {
        public string? BranchTitle { get; set; }
        public string? UserTitle { get; set; }
    }
}
