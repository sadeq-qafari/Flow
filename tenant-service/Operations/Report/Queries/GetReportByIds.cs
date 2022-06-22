using Saanaa.Core.Meteor;

namespace Tenant.Operations.Report.Queries
{
    public class GetReportByIds : SaanaaDbQueryByIds<Report>
    {
        public GetReportByIds() : base("[Tenant].[Report]")
        {
        }
    }
}