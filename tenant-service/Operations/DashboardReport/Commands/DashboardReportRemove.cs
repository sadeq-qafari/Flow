using Saanaa.Core.Meteor;

namespace Tenant.Operations.DashboardReport.Commands
{
    public class DashboardReportRemove : SaanaaDbDeleteAsync
    {
        public DashboardReportRemove() : base("[Tenant].[DashboardReport]")
        {
        }
    }
}