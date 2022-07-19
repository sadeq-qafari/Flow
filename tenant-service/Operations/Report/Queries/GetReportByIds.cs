using Core.Meteor;

namespace Tenant.Operations.Report.Queries
{
    public class GetReportByIds : DbQueryByIds<Report>
    {
        public GetReportByIds() : base("[Tenant].[Report]")
        {
        }
    }
}