using Saanaa.Core.Meteor;

namespace Tenant.Operations.Report.Queries
{
    public class GetReportExcel : SaanaaDbQueryExcel<Report>
    {
        public GetReportExcel() : base("[Tenant].[Report]")
        {
        }
    }
}