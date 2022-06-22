using Saanaa.Core.Meteor;

namespace Tenant.Operations.Report.Commands
{
    public class ReportRemove : SaanaaDbDeleteAsync
    {
        public ReportRemove() : base("[Tenant].[Report]")
        {
        }
    }
}