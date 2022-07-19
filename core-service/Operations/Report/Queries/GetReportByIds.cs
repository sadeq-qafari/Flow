using Core.Meteor;

namespace Core.Operations.Report.Queries
{
    public class GetReportByIds : DbQueryByIds<Report>
    {
        public GetReportByIds() : base("[Core].[Report]")
        {
        }
    }
}