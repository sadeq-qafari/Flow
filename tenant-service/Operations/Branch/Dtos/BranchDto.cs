namespace Tenant.Operations.Branch.Dtos
{
    public class BranchDto : Branch
    {
        public string? TenantTitle { get; set; }
        public string? CityTitle { get; set; }
        public string? ParentTitle { get; set; }
    }
}
