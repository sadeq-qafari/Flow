using Core.Operations.ReportDbServer.Dtos;
using Saanaa.Core.Meteor;

namespace Core.Operations.ReportDbServer.Commands
{
    public class ReportDbServerUpdate : SaanaaDbUpdateAsync<ReportDbServerUpdateInDto>
    {
        public ReportDbServerUpdate() : base("[Core].[ReportDbServer]",
            @"[Title]=@Title,
					[ConnectionString]=@ConnectionString,
					[EngineTypeLookup]=@EngineTypeLookup")
        {
        }
    }
}