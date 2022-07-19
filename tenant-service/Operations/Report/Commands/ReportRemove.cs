using Core.Meteor;

namespace Tenant.Operations.Report.Commands
{
    public class ReportRemove : DbDeleteAsync
    {
        public ReportRemove() : base("[Tenant].[Report]")
        {
        }
    }
}