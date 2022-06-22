namespace Identity.Operations.Database.User.Dtos
{
    public class GetUserPermissionsInDto
    {
        public int ActionBy { get; set; }
        public int? TenantId { get; set; }
        public int? BranchId { get; set; }
    }
}
