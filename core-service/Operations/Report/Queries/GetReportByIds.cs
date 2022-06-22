using Saanaa.Core.Meteor;

namespace Core.Operations.Report.Queries
{
    public class GetReportByIds : SaanaaDbQueryByIds<Report>
    {
        public GetReportByIds() : base("[Core].[Report]")
        {
        }
    }
}