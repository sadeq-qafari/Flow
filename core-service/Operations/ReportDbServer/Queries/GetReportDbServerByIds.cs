using Core.Meteor;

namespace Core.Operations.ReportDbServer.Queries
{
    public class GetReportDbServerByIds : DbQueryByIds<ReportDbServer>
    {
        public GetReportDbServerByIds() : base("[Core].[ReportDbServer]")
        {
        }
    }
}