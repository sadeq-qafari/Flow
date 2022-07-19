using Core.Meteor;

namespace Tenant.Operations.Dashboard.Dtos
{
    public class GetDashboardsInDto : IHaveActionBy,IHaveTenant,IHaveBranch
    {
        public int ActionBy { get; set; }
        public int? TenantId { get; set; }
        public int? BranchId { get; set; }
    }
}
