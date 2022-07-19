using Core.Meteor;

namespace Core.Operations.ReportDbServer.Queries
{
    public class GetReportDbServerAsDropDown : DbQueryAsDropDown<ReportDbServer>
    {
        public GetReportDbServerAsDropDown() : base("[Core].[ReportDbServer]")
        {
        }
    }
}
