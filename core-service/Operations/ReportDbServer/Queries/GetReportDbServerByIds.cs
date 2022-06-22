using Saanaa.Core.Meteor;

namespace Core.Operations.ReportDbServer.Queries
{
    public class GetReportDbServerByIds : SaanaaDbQueryByIds<ReportDbServer>
    {
        public GetReportDbServerByIds() : base("[Core].[ReportDbServer]")
        {
        }
    }
}