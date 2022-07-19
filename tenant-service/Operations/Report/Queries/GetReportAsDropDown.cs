using Core.Meteor;

namespace Tenant.Operations.Report.Queries
{
    public class GetReportAsDropDown : DbQueryAsDropDown<Report>
    {
        public GetReportAsDropDown() : base("[Tenant].[Report]")
        {
        }
    }
}
