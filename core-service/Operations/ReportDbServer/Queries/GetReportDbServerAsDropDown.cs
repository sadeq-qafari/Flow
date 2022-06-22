using Saanaa.Core.Meteor;

namespace Core.Operations.ReportDbServer.Queries
{
    public class GetReportDbServerAsDropDown : SaanaaDbQueryAsDropDown<ReportDbServer>
    {
        public GetReportDbServerAsDropDown() : base("[Core].[ReportDbServer]")
        {
        }
    }
}
