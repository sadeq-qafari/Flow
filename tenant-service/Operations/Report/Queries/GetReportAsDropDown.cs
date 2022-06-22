using Saanaa.Core.Meteor;

namespace Tenant.Operations.Report.Queries
{
    public class GetReportAsDropDown : SaanaaDbQueryAsDropDown<Report>
    {
        public GetReportAsDropDown() : base("[Tenant].[Report]")
        {
        }
    }
}
