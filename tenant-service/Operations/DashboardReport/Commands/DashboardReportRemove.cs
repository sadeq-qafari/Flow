using Core.Meteor;

namespace Tenant.Operations.DashboardReport.Commands
{
    public class DashboardReportRemove : DbDeleteAsync
    {
        public DashboardReportRemove() : base("[Tenant].[DashboardReport]")
        {
        }
    }
}