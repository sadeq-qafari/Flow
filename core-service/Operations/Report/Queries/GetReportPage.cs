using Core.Operations.Report.Dtos;
using Saanaa.Core.Meteor;

namespace Core.Operations.Report.Queries
{
    public class GetReportPage : SaanaaDbQueryPage<ReportDto>
    {
        public GetReportPage() : base("[Core].[Report]")
        {
        }
        
    }
}