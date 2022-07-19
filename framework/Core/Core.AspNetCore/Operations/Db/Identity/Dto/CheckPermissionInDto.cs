namespace Core.AspNetCore.Operations.Db.Identity.Dto
{
    public class CheckPermissionInDto
    {
        public string PermissionName { get; set; }
        public int UserId { get; set; }
        public int? BranchId { get; set; }
        public int? TenantId { get; set; }
    }
}
