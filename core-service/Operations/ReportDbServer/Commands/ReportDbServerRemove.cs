using Saanaa.Core.Meteor;

namespace Core.Operations.ReportDbServer.Commands
{
    public class ReportDbServerRemove : SaanaaDbDeleteAsync
    {
        public ReportDbServerRemove() : base("[Core].[ReportDbServer]")
        {
        }
    }
}