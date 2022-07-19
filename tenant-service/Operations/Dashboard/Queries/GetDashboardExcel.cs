using Core.Meteor;

namespace Tenant.Operations.Dashboard.Queries
{
    public class GetDashboardExcel : DbQueryExcel<Dashboard>
    {
        public GetDashboardExcel() : base("[Tenant].[Dashboard]")
        {
        }
    }
}