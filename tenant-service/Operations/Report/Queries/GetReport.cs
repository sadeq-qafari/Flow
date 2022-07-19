using Core.Meteor;

namespace Tenant.Operations.Report.Queries
{
    public class GetReport : DbSelectAsync<Report?>
    {
        public GetReport() : base("[Tenant].[Report]")
        {
        }
    }
}