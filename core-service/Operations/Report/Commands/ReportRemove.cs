using Core.Meteor;

namespace Core.Operations.Report.Commands
{
    public class ReportRemove : DbDeleteAsync
    {
        public ReportRemove() : base("[Core].[Report]")
        {
        }
    }
}