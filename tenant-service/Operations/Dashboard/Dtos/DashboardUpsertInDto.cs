using Meteor.Operation.Db.Default;
using Saanaa.Core.Meteor;

namespace Tenant.Operations.Dashboard.Dtos
{
    public class DashboardUpsertInDto : IHaveActionBy, IHaveTenant, IDbModel<int?>
    {
        public int DashboardId { get; set; }
        public string? DashboardTitle { get; set; }
        public string ReportIds { get; set; }
        public int ActionBy { get; set; }
        public int? TenantId { get; set; }
        public int? Id => DashboardId;
    }
}
