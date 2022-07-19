using Core.Meteor;
using Core.Operations.Report.Dtos;

namespace Core.Operations.Report.Queries
{
    public class GetReportPage : DbQueryPage<ReportDto>
    {
        public GetReportPage() : base("[Core].[Report]")
        {
        }
        
    }
}