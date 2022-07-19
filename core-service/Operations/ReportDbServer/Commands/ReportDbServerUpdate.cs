using Core.Meteor;
using Core.Operations.ReportDbServer.Dtos;

namespace Core.Operations.ReportDbServer.Commands
{
    public class ReportDbServerUpdate : DbUpdateAsync<ReportDbServerUpdateInDto>
    {
        public ReportDbServerUpdate() : base("[Core].[ReportDbServer]",
            @"[Title]=@Title,
					[ConnectionString]=@ConnectionString,
					[EngineTypeLookup]=@EngineTypeLookup")
        {
        }
    }
}