using Saanaa.Core.Meteor;

namespace Tenant.Operations.Dashboard.Commands
{
    public class DashboardRemove : SaanaaDbDeleteAsync
    {
        public DashboardRemove() : base("[Tenant].[Dashboard]")
        {
        }
    }
}