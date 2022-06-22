using Saanaa.Core.Meteor;

namespace Core.Operations.Report.Queries
{
    public class GetReportAsDropDown : SaanaaDbQueryAsDropDown<Report>
    {
        public GetReportAsDropDown() : base("[Core].[Report]")
        {
        }
    }
}
