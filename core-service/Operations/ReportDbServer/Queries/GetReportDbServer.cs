using Saanaa.Core.Meteor;

namespace Core.Operations.ReportDbServer.Queries
{
    public class GetReportDbServer : SaanaaDbSelectAsync<ReportDbServer?>
    {
        public GetReportDbServer() : base("[Core].[ReportDbServer]")
        {
        }
    }
}