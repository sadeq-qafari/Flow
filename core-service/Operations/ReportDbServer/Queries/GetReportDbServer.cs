using Core.Meteor;

namespace Core.Operations.ReportDbServer.Queries
{
    public class GetReportDbServer : DbSelectAsync<ReportDbServer?>
    {
        public GetReportDbServer() : base("[Core].[ReportDbServer]")
        {
        }
    }
}