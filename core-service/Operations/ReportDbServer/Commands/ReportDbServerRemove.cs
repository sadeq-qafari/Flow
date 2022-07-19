using Core.Meteor;

namespace Core.Operations.ReportDbServer.Commands
{
    public class ReportDbServerRemove : DbDeleteAsync
    {
        public ReportDbServerRemove() : base("[Core].[ReportDbServer]")
        {
        }
    }
}