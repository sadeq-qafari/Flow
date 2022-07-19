using Core.Meteor;

namespace Core.Operations.Report.Queries
{
    public class GetReportAsDropDown : DbQueryAsDropDown<Report>
    {
        public GetReportAsDropDown() : base("[Core].[Report]")
        {
        }
    }
}
