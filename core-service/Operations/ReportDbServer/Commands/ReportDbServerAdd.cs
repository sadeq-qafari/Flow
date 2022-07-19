using Core.Meteor;
using Core.Operations.ReportDbServer.Dtos;

namespace Core.Operations.ReportDbServer.Commands
{
    public class ReportDbServerAdd : DbInsertAsync<ReportDbServerAddInDto>
    {
        public ReportDbServerAdd() : base("[Core].[ReportDbServer]",
            @"[Title],
						[ConnectionString],
						[EngineTypeLookup]",
            @"@Title,
						@ConnectionString,
						@EngineTypeLookup")
        {
        }
    }
}

