using Saanaa.Core.Meteor;

namespace Core.Operations.Report.Commands
{
    public class ReportRemove : SaanaaDbDeleteAsync
    {
        public ReportRemove() : base("[Core].[Report]")
        {
        }
    }
}